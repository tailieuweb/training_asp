$(document).ready(() => {
    //get elemtents in dom
    const programingItem = document.querySelectorAll(".new__right__box__item");
    const bannerLeftBoxTitle = document.querySelector(".banner__left__box__title h2");
    const bannerMiddleBoxItemLeftTitle = document.querySelectorAll(".banner__middle__box__item__left__title h2");
    const searchData = document.getElementById("searchData");
    const newLeftBox = document.querySelector(".new__left__box");
    const bannerRightBoxAll = document.querySelector(".banner__right__box__all");
    const btnShowUser = document.getElementById("btn_Show_User");
    let endOfArticle = false;
    let endOfUser = false;
    const data = {
        searchedContent: searchData.value,
        articleType: findFirstProgramingActive(),
        take: 2,
        skip:0
    }
    const userData = {
            take: 5,
            skip: 0
    }   
    class Home {
        constructor() {
        
        };
        async fetchArticles(fetchData) {
            const response = await fetch("/Home/getAllArticlesBySearchType", {
                method: "POST",
                credentials: "include",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(fetchData)
            }).catch(error => console.log(error));
            var result = await response.json();
            return result;
        }
        async AddNewLeftBox(list) {
            var getList = await list;
            if (getList != null) {
                if (getList.articleList != "") {
                    getList.articleList.forEach((value, index) => {
                        newLeftBox.insertAdjacentHTML("beforeend", '<div class="new__left__box__item">' +
                            '                <!-- New Left Box Item Left-->' +
                            '                <div class="new__left__box__item__left">' +
                            '                    <!-- New Left Box Item Left Link-->' +
                            '                    <div class="new__left__box__item__left__link">' +
                            '                        <a href="#">' +
                            '                            <img src="/img/logo-banner.png" alt="">' +
                            '                            <h4>medium articles</h4>' +
                            '                        </a>' +
                            '                    </div>' +
                            '                    <!-- New Left Box Item Left Title-->' +
                            '                    <div class="new__left__box__item__left__title">' +
                            '                        <a href="/WatchArticle/Index/' + `${value.ariticleId}` + '">' +
                            '                            <h2>' + `${HandleArticleTitle(value.title)}` + '</h2>' +
                            '                        </a>' +
                            '                    </div>' +
                            '                    <!-- New Left Box Item Left Content-->' +
                            '                    <div class="new__left__box__item__left__content">' +
                            '                        <p>' + `${HandleArticleContent(RemoveH1Title(value.content))}` + '</p>' +
                            '                    </div>' +
                            '                    <!-- New Left Box Item Left Time-->' +
                            '                    <div class="new__left__box__item__left__time">' +
                            '                        <!-- New Left Box Item Left Time Left-->' +
                            '                        <div class="new__left__box__item__left__time__left">' +
                            '                            <!-- New Left Box Item Left Time Left Day-->' +
                            '                            <div class="new__left__box__item__left__time__left__day">' +
                            '                                <div class="new__left__box__item__left__time__left__day__minute">' +
                            '                                    <span>' + `${HandleDistanceTime(value.date)}` + '</span>' +
                            '                                </div>' +
                            '                            </div>' +
                            '                        </div>' +
                            '                    </div>' +
                            '                    <!-- New Left Box Item Left Like-->' +
                            '                    <div class="new__left__box__item__left__like">' +
                            '                        <span class="thumb thumbs-up"><i class="fas fa-sign-language"></i></span>' +
                            '                        <p>' + `${value.like}` + '</p>' +
                            '                    </div>' +
                            '                </div><!-- New Left Box Item Left -->' +
                            '                <!-- New Left Box Item Right -->' +
                            '                <div class="new__left__box__item__right">' +
                            '                    <a href="/WatchArticle/Index/' + `${value.ariticleId}` + '">' +
                            `${value.avatar ? '<img src="/Article_Image/' + `${value.ariticleId + "/" + value.avatar}` + '" alt="">' : ""}` +
                            '                    </a>' +
                            '                </div><!--  New Left Box Item Right-->' +
                            '            </div>');
                    })
                }  
            }    
        }
        async fetchUsers(fetchData) {
            const response = await fetch("/Home/getAllUser", {
                method: "POST",
                credentials: "include",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(fetchData)
            }).catch(error => console.log(error));
            var result = await response.json();
            if (Object.entries(result).length != 0) {
                if (result.userList) {
                    if (result.userList.length !== userData.take) {
                        btnShowUser.style.display = "none";
                    }
                    return result;
                }
            } else {
                return null;
            }
           
        }
        async AddNewUserBox(list) {
            var getUserList = await list;
            console.log(getUserList);
            if (getUserList.userList) {
                getUserList.userList.forEach((value, index) => {
                    bannerRightBoxAll.insertAdjacentHTML("beforeend",
                        '<div class="banner__right__box__all__item">' +
                        '                    ' +
                        '                    <div class="banner__right__box__all__item__content">' +
                        '                        <a href="#">' +
                        '                            <img src="' + `${value.image ? "/User_Image/" + value.id + "/" +
                            value.image : "/img/emty_avatar.jpg"}` + '" alt="">' +
                        '                        </a>' +
                        '                        <div class="banner__right__box__all__item__content__middle">' +
                        '                            <a href="/PersonalPage/Index/' + `${value.id}` + '">' +
                        '                                <h2>' + value.fullName + '</h2>' +
                        '                                <h4>' +
                        '                                    Lorem ipsum dolor, sit amet consectetur adipisicing elit. Doloribus ipsa fugit vel possimus' +
                        '                                    perspiciatis eos culpa doloremque.' +
                        '                                </h4>' +
                        '                            </a>' +
                        '                        </div>' +
                        '                        ' +
                        '                    </div>' +
                        '                </div>'
                    );
                })
            }
        }
    }
    var home = new Home();
    //get all user
    var userList = home.fetchUsers(userData);
    home.AddNewUserBox(userList);
    //get all related articles
    var articlelist = home.fetchArticles(data);
    home.AddNewLeftBox(articlelist);
    //edit title of first article
    bannerLeftBoxTitle.innerHTML = handleTitle(bannerLeftBoxTitle.innerHTML);
    //edit 4 title of news articles
    bannerMiddleBoxItemLeftTitle.forEach((value, index) => {
        value.innerHTML = handleTitle(value.innerHTML);
    });
    //Remove <h1> into html
    function RemoveH1Title(content) {
        let str = content.replace(/(<(h1)>)+([^>])+(<(\/h1)>)/ig, "");
        return str;
    }
    //Handle article Content
    function HandleArticleTitle(content) {
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
    function HandleArticleContent(content) {
        if (content) {
            var getNewContent = content.replace(/(<([^>]+)>)/ig, " ");
            if (getNewContent.length > 125) {
                return getNewContent.replace(getNewContent.substring(125), "...");
            } else {
                return getNewContent;
            }
        } else {
            return "Have't feedbacks";
        }
    }
    // Handle DistanceTime: convert 22/12/2020 into string
    function HandleDistanceTime(dateTime) {
        const event = new Date(dateTime);
        return event.toDateString();
    }
    //hand title function
    function handleTitle(title) {
        return title.replace(title.substring(40), "...");
    }
    //Add "programing_active" class for items
    programingItem.forEach((value, index) => {
        value.addEventListener("click", async() => {
            deleteProgramingActive();
            data.skip = 0;
            data.articleType = value.getAttribute("articletype");
            endOfArticle = false;
            value.classList.add("programing_active");
            newLeftBox.innerHTML = '';
            console.log("click",data);
            let articlelist = await home.fetchArticles(data);
            console.log("click",articlelist);
            home.AddNewLeftBox(articlelist);
        });
    })
    //delete "programing_active" class for items
    function deleteProgramingActive() {
        programingItem.forEach((value, index) => {
            if (value.classList.contains("programing_active")) {
                value.classList.remove("programing_active");
            }
        });
    }
    // find the first element have programing_active
    //let tam = '';
    function findFirstProgramingActive() {
        let parseArray = Array.from(programingItem);
        for (let item of parseArray) {
            if (item.classList.contains("programing_active")) {
                return item.getAttribute("articletype");
            }
        }
    }
    // handle Scrollwindow 
    window.addEventListener("scroll", async () => {
        const documentHeight = $(document).height();
        const windowHeight = $(window).height();
        if (Math.floor($(window).scrollTop() + 5) >= (documentHeight - windowHeight)) {
            if (endOfArticle == false || newLeftBox.innerHTML != '') {
                data.skip += 2;
                let get = await home.fetchArticles(data);
                if (get.articleList.length !== data.take) {
                    endOfArticle = true;
                }
                home.AddNewLeftBox(get);
            }
        }
    });
    // fetch data into Database
    searchData.addEventListener("change", async (e) => {
        data.searchedContent = e.target.value;
        data.skip = 0;
        endOfArticle = false;
        newLeftBox.innerHTML = '';
        let get = await home.fetchArticles(data);
        home.AddNewLeftBox(get);
    });
    // Button show user
    btnShowUser.addEventListener("click", () => {
        if (endOfUser == false) {
            userData.skip += 5;
            var userList = home.fetchUsers(userData);
            home.AddNewUserBox(userList);
        }
    })
})