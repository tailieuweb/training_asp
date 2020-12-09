$(document).ready(function () {
    //Get all element html into javascript
    const menu = document.querySelectorAll(".menu ul li");
    const info = document.querySelector(".info");
    const searchBox = document.getElementById("searchBox");
    let endOfArticle = false;
    const btnDanger = document.querySelector(".btn-danger");
    //fetch data
    const data = { 
        articleType: 0,
        take: 5,
        skip: 0,
        searchedContent:""
    };
    // localStorage data
    const StoriesLocalStorage = {
        articleType: 0
    }
    // Thiết lập cho button active khi localstorage chưa tồn tại
    LoadLStorageAndTypeBtn(); 
    function LoadLStorageAndTypeBtn() {
        if (localStorage.getItem("Stories")) {
            const lStorage = JSON.parse(localStorage.getItem("Stories"));
            menu[lStorage.articleType].classList.add("active");
        } else {
            localStorage.setItem("Stories", JSON.stringify(StoriesLocalStorage))
            menu[0].classList.add("active");
        }
    }
    // Set button active and localstorage khi click
    function SetLStorageAndTypeBtn(index) {
        if (localStorage.getItem("Stories")) {
            RemoveAllActiveClass();
            StoriesLocalStorage.articleType = index;
            localStorage.setItem("Stories", JSON.stringify(StoriesLocalStorage));
            menu[index].classList.add("active");
        }
    };
    // Remove all active class in "Draft" and "Published";
    function RemoveAllActiveClass() {
        menu.forEach((value, index) => {
            value.classList.remove("active");
        });
    }
    // Handle Content : because content of article had contain html string
    function HandleArticleContent(content) {
        if (content) {
            var getNewContent = content.replace(/(<([^>]+)>)/ig, " ");
            if (getNewContent.length > 45) {
                return getNewContent.replace(getNewContent.substring(45), "...");
            } else {
                return getNewContent;
            }
        } else {
            return "Have't feedbacks";
        }
    }
    // Handle DistanceTime: convert 22/12/2020 into string
    function HandleDistanceTime(startTime, endTime) {
        var result = (startTime - endTime) / (1000 * 60 * 60 * 24);
        var parseFloor = Math.floor(result);
        return parseFloor != 0 ? "Last read " + parseFloor + " day ago" : "Just read today";
    }
    // Set data.articleType must be the localStorage same
    SetDataWithLoad();
    function SetDataWithLoad() {
        const lStorage = JSON.parse(localStorage.getItem("Stories"));
        data.articleType = lStorage.articleType;
    }
    // Set data.articleType when clicked
    function SetDataWithClick(index) {
        data.articleType = index;
        data.take = 5;
        data.skip = 0;
        endOfArticle = false;
    }
    // Set data.articleType when change input
    function SetDataWithChange(content) {
        const lStorage = JSON.parse(localStorage.getItem("Stories"));
        data.articleType = lStorage.articleType;
        data.take = 5;
        data.skip = 0;
        data.searchedContent = content;
        endOfArticle = false;
    }
    // Delete Article
    async function FetchDeleteArticle(fetchData,element){
        const response = await fetch("/Stories/DeleteArticle",
            {
                method: "POST",
                credentials: "include",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(fetchData)
            }).catch(error => console.log(error));
        var result = await response.json();
        if (result.deleted) {
            info.removeChild(element);
        }
    }
    // Fetch data into server
    FetchDataIntoServer(data);
    async function FetchDataIntoServer(fetchData) {
        if (!endOfArticle) {
            const response = await fetch("/Stories/GetArticleHaveType",
                {
                    method: "POST",
                    credentials: "include",
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(fetchData)
                }).catch(error => console.log(error));
            var result = await response.json();
            if (!endOfArticle) {
                if (result.dataList.length != 0) {
                    result.dataList.forEach((value, index) => {
                        info.insertAdjacentHTML("beforeend", '<div class="info__box">' +
                            '<div class="info__box__title"><p>' + `${HandleArticleContent(value.title)/*handleArticleContent func*/}` + '</p></div><div class="info__box__content">' +
                            '<p>' + `${HandleArticleContent(value.content)/*handleArticleContent func*/}` + '</p></div>' +
                            '<button status ="' + `${value.status}` + '" articleId="' + `${value.articleId}` + '" class="changeBtn">change status</button>' +
                            '<div class="info__box__time"><div class="info__box__time__last">' +
                            '<span>' + `${new Date(value.date).toDateString()}` + '</span></div><div class="info__box__time__cham">' +
                            '<span>.</span></div><div class="info__box__time__read"><span>' + HandleDistanceTime(Date.now(), new Date(value.date)) + '</span>' +
                            '</div><div class="info__box__time__muiten"><div class="dropdown"><button class="btn btn-primary" type="button" id="dropdownMenuButton" data-toggle="dropdown">' +
                            '<i class="fa fa-angle-down" aria-hidden="true"></i ></button><div class="dropdown-menu" aria-labelledby="dropdownMenuButton">' +
                            '<a class="dropdown-item" href="/WriteArticle/Index/' + `${value.articleId}` + '"><div class="left_button"><span>Edit your profile</span></div>' +
                            '<div class="right_button"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></div></a>' +
                            '<span class="dropdown-item deleteBtn" articleId="' + `${value.articleId}` + '"><div class="left_button"><div class="modalDelete" data-toggle="modal" data-target="#myModal">' +
                            '<span class="titleDelete"> Delete your profile</span></div>' +
                            '</div><div class="right_button"><i class="fa fa-trash-o" aria-hidden="true"></i></div>' +
                            '</span></div></div></div></div></div>');
                    });
                }
            }
            if (result.dataList[4] != null) {
                endOfArticle = false;
            } else {
                endOfArticle = true;
            }
            //click change status of aritcle
            const changeBtn = document.querySelectorAll(".changeBtn");
            const infoBox = document.querySelectorAll(".info__box");
            const deleteBtn = document.querySelectorAll(".deleteBtn");
            changeBtn.forEach((value, index) => {
                value.addEventListener("click", async () => {
                    const statusValue = value.getAttribute("status");
                    const articleIdValue = value.getAttribute("articleId");
                    const changedData = {
                        articleId: articleIdValue,
                        status: statusValue
                    }
                    var result = await FetchStatusAndChange(changedData);
                    if (result != false) {
                        infoBox[index].style.display = "none";
                    }
                });
            });
            //delete article 
            deleteBtn.forEach((value, index) => {
                value.addEventListener("click", () => {
                    btnDanger.addEventListener("click", () => {
                        console.log(value.getAttribute("articleId"));
                        const deleteData = {
                            ArticleId: value.getAttribute("articleId")
                        }
                        FetchDeleteArticle(deleteData, infoBox[index]);
                    });
                });
            });
        }
    }
    // Fetch change status of article
    async function FetchStatusAndChange(fetchData) {
        const response = await fetch("/Stories/ChangeArticleStatus", {
            method: "POST",
            credentials: "include",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(fetchData)
        });
        const result = await response.json();
        if (result.changed != null) {
            return result.changed;
        } else {
            return false;
        }
    }
    // Click elements like "Draft" and "Published" Button
    menu.forEach((value, index) => {
        value.addEventListener("click", async () => {
            info.innerHTML = '';
            SetLStorageAndTypeBtn(index);
            SetDataWithClick(index);
            await FetchDataIntoServer(data);
        });
    });
    // Scroll window and upload data
    window.addEventListener("scroll", async () => {
        const documentHeight = $(document).height();
        const windowHeight = $(window).height();
        if (Math.floor($(window).scrollTop() + 5) >= (documentHeight - windowHeight)) {
            if (endOfArticle == false) {
                data.skip += 5;
               await FetchDataIntoServer(data);
            }
        }
    });
    //search data  and uploading data on view
    searchBox.addEventListener("change", async (e) => {
        info.innerHTML = '';
        SetDataWithChange(e.target.value);
        await FetchDataIntoServer(data);
    })
});
