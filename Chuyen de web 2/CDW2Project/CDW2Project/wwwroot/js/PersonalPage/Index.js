﻿const btnChangeAvatar = document.querySelector(".btnChangeAvatar");
const avatarImg = btnChangeAvatar.querySelector("img");
const uploadPersonalFile = document.getElementById("uploadPersonalFile");
const getBrowseUrl = window.location.href;
const browseUrlArr = getBrowseUrl.split("/");
const getUserId = browseUrlArr[browseUrlArr.length - 1];
const infoRightBox = document.querySelector(".info__right__box");
let endOfArticle = false;
const languageBoxItem = document.querySelectorAll(".language__box__item");
const scrollBox = document.querySelector(".scroll_box");
const userArticleData = {
    status: 1,
    take: 4,
    skip: 0,
    ArticleArticleTypeId:"other",
    searchedContent: "",
    userId:getUserId
};
class Personal {
    constructor() {

    }
    async fetchGetUserArticles(fetchData) {
        const response = await fetch("/PersonalPage/GetUserArticles",
            {
                method: "POST",
                credentials: "include",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(fetchData)
            }).catch(error => console.log(error));
        var result = await response.json();
        if (Object.entries(result).length != 0) {
            if (result.dataList.length > 0) {
                if (result.dataList[3]) {
                    endOfArticle = false;
                } else {
                    endOfArticle = true;
                }
                return result;
            } else {
                endOfArticle = true;
                return result;
            }
        }
    }
    async insertArticlesIntoBox(list) {
        var getDataList = await list;
        getDataList.dataList.forEach((value, index) => {
            scrollBox.insertAdjacentHTML("beforeend", '<div class="info__right__box__item">' +
                '                ' +
                '                <div class="info__right__box__item__left">' +
                '                    ' +
                '                    <div class="info__right__box__item__left__link">' +
                '                        <a href="#">' +
                '                            <img src="/img/logo-banner.png" alt="">' +
                '                            <h4>Lorem ipsum dolor sit amet</h4>' +
                '                        </a>' +
                '                    </div>' +
                '                    ' +
                '                    <div class="info__right__box__item__left__title">' +
                '                        <a href="/WatchArticle/Index/' + `${value.ariticleId}` + '">' +
                '                            <h2>' + `${HandleArticleTitle(value.title)}` + '</h2>' +
                '                        </a>' +
                '                    </div>' +
                '                    <!-- Information Right Box Item Left Content-->' +
                '                    <div class="info__right__box__item__left__content">' +
                '                        <p>' +
                                                `${HandleArticleContent(RemoveH1Title(value.content))}` +
                '                        </p>' +
                '                    </div>' +
                '                    <!-- Information Right Box Item Left Time-->' +
                '                    <div class="info__right__box__item__left__time">' +
                '                        <!-- Information Right Box Item Left Time Left-->' +
                '                        <div class="info__right__box__item__left__time__left">' +
                '                            <!-- Information Right Box Item Left Time Left Day-->' +
                '                            <div class="info__right__box__item__left__time__left__day">' +
                '                                <div class="info__right__box__item__left__time__left__day__minute">' +
                '                                    <span>' + `${HandleDistanceTime(value.date) }`+'</span>' +
                '                                </div>' +
                '                            </div>' +
                '                        </div>' +
                '                    </div>' +
                '                    <!-- Information Right Box Item Left Like-->' +
                '                    <div class="info__right__box__item__left__like">' +
                '                        <span class="thumb thumbs-up"><i class="fas fa-sign-language"></i></span>' +
                '                        <p>' + `${value.like}` + '</p>' +
                '                    </div>' +
                '                </div><!-- Information Right Box Item Left -->' +
                '                <!-- Information Right Box Item Right -->' +
                '                <div class="info__right__box__item__right">' +
                '                    <a href="#">' +
                '                        <img src="'+`${value.avatar ? /Article_Image/ + value.ariticleId + "/" + value.avatar : ""}` + '" alt="">' +
                '                    </a>' +
                '                </div><!--  Information Right Box Item Right-->' +
                '            </div>');
        })
    }
}
var personal = new Personal();
var getDataList = personal.fetchGetUserArticles(userArticleData);
personal.insertArticlesIntoBox(getDataList);
//Change personal avatar
uploadPersonalFile.addEventListener("change", async function () {
    const file = this.files[0];
    if (file) {
        const reader = new FileReader();
        reader.addEventListener("load", function () {
            avatarImg.setAttribute("src", this.result);
        })
        reader.readAsDataURL(file);
        var formData = new FormData();
        formData.append('model.file', file);
        formData.append('model.userid', getUserId);
        // personal.fetchUploadPersonalImage(formData);
        const reponse = await fetch("/PersonalPage/UploadPersonalImage", {
            method: "POST",
            credentials: "include",
            body:formData
        });
        const result = await reponse.json();
        if (result.entries(a).length !== 0) {
            console.log("update image is successful", result)
        } else {
            console.log("update image is not successful", result)
        }
    }
});
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
// click item to change article type
languageBoxItem.forEach((value, index) => {
    value.addEventListener("click", async () => {
        deleteItemHaveActive();
        value.classList.add("active");
        const getArticleTypeId = value.getAttribute("articleTypeId");
        userArticleData.ArticleArticleTypeId = getArticleTypeId;
        userArticleData.skip = 0;
        endOfArticle = false;
        scrollBox.innerHTML = '';
        var getDataList = await personal.fetchGetUserArticles(userArticleData);
        await personal.insertArticlesIntoBox(getDataList);
    })
});
// delete item and add active class into item clicked
function deleteItemHaveActive() {
    languageBoxItem.forEach((value, index) => {
        value.classList.remove("active");
    });
}
//scroll article box
infoRightBox.addEventListener("scroll", async function () {
    const infoRightBoxHeight = infoRightBox.clientHeight;
    const scrollBoxHeight = scrollBox.clientHeight;
    if (scrollBoxHeight >= infoRightBoxHeight) {
        if (Math.floor(infoRightBox.scrollTop) - 18 >= (scrollBoxHeight - infoRightBoxHeight)) {
            if (!endOfArticle) {
                userArticleData.skip += 4;
                var getDataList = await personal.fetchGetUserArticles(userArticleData);
                await personal.insertArticlesIntoBox(getDataList);
            }
        }
    }
})