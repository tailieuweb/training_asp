const clapNotification = document.querySelector(".clapComment__post__number");
const showClapNotification = document.querySelector(".clapComment__post");
const clapBtn = document.querySelector(".clapComment__clap");
const clapDecription = document.querySelector(".clapComment__clap__frame__span");
const messageBox = document.querySelector(".messageBox");
var setBox = null;
const getBrowseUrl = window.location.href;
const browseUrlArr = getBrowseUrl.split("/");
const getUserId = browseUrlArr[browseUrlArr.length - 1];
let setTimeOutBox = null;
const commentField = document.getElementById("commentField");
const deleteNotification__BtnNode__cancel = document.querySelector("#deleteNotification__BtnNode__cancel");
const deleteNotification__BtnNode__ok = document.querySelector("#deleteNotification__BtnNode__ok");
var getCommentId = "";
var getCard = null; 
var getChildComment = null;
var countCard = null;
//edit comment 
const editFrame = document.querySelector(".editFrame");
const blackFrame = document.querySelector(".blackFrame");
const editInput = document.querySelector("#editInput");
const editNotification_BtnNode_ok = document.querySelector("#editNotification_BtnNode_ok");
const editNotification_BtnNode_cancel = document.querySelector("#editNotification_BtnNode_cancel");
const errorNone = document.querySelector(".error-none");
const responses = document.querySelector(".responses");
class WatchArticle{
    constructor() {

    }
    async RefreshArticleLikeProperty(fetchData) {
        const response = await fetch("/WatchArticle/UpdateLikeOfArticle", {
            method: "POST",
            credentials: "include",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(fetchData)
        });
        const result = await response.json();
        if (Object.keys(result).length > 0) {
            clapDecription.innerHTML = result.like;
        }
    }
    async GetLikeOfArticle() {
        const response = await fetch("/WatchArticle/GetLikeOfArticle/" + getUserId + "", {
            method: "GET",
            credentials: "include",
            headers: {
                'Content-Type': 'application/json'
            },
        });
        const result = await response.json();
        if (Object.keys(result).length > 0) {
            clapDecription.innerHTML = result.like;
        }
    }
    async PostCommentUser(fetchData) {
        if (fetchData != "") {
            const response = await fetch("/WatchArticle/PostCommentUser", {
                method: "POST",
                credentials: "include",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(fetchData)
            });
            const result = await response.json();
            if (Object.keys(result).length > 0) {
                if (result.add) {
                    messageBox.insertAdjacentHTML("afterbegin", '<div class="card card-body peter">' +
                        '                            <div class="titleRe">' +
                        '                                <div class="titleRe__avatar">' +
                        `${result.user.image ? '<img src="/User_Image/' + `${result.user.id}/${result.user.image}` + '" class="titleRe__avatar__img">' : '<img src="/img/emty_avatar.jpg" alt="">'}` +
                        '                                </div>' +
                        '                                <div class="titleRe__name">' +
                        '                                    <h3 class="titleRe__name__title">DoanHongThang</h3>' +
                        '                                    <span class="titleRe__name__time">Wednesday, 16 December 2020</span>' +
                        '                                </div>' +
                        '                            </div>' +
                        '                            <div class="commentRe">' +
                        '                                <span class="commentRe__content">' + `${result.content}` +
                        '                                </span>' +
                        '                            </div>' +
                        '                             <div class="watchArticle_EditBox">' +
                        '                                <span class="editComment_btn watchBtn" commentId="' + `${result.commentId}` + '"><i class="far fa-edit"></i></span>' +
                        '                                <span class="deleteComment_btn watchBtn" commentId="' + `${result.commentId}` + '"><i class="fas fa-eraser"></i></span>' +
                        '                            </div>' +
                        '                        </div>');
                }
            }
        }
        const card = document.querySelectorAll(".peter");
        responses.innerHTML = "Responses (" + card.length + ")";
        // delete form 
        const deleteComment_btn = document.querySelectorAll(".deleteComment_btn");
        // edit form notification
        const editComment_btn = document.querySelectorAll(".editComment_btn");

        deleteComment_btn.forEach((value, index) => {   
            value.addEventListener("click", async () => {
                getCommentId = value.getAttribute("commentId");
                getCard = card[index];
                blackFrame.classList.add("showFrame");        
            });
        });
        editComment_btn.forEach((value, index) => {
            value.addEventListener("click", () => {
                console.log("as");
                errorNone.classList.add("error-none");
                getCommentId = value.getAttribute("commentId");
                const getConent = card[index].children[1].children[0].innerHTML;
                getChildComment = card[index].children[1].children[0];
                editFrame.classList.add("showEditComment");
                editInput.value = getConent.toString().trim();
            });
        });
    }
    async DeleteComment(fetchData) {
        console.log("delete fetch",fetchData);
        const response = await fetch("/WatchArticle/DeleteComment/" + `${fetchData}` + "", {
            method: "DELETE",
            credentials: "include",
            headers: {
                'Content-Type': 'application/json'
            },
        });
        const result = await response.json();
        return result;
    }
    async UpdateComment(fetchData) {
        const response = await fetch("/WatchArticle/UpdateComment", {
            method: "POST",
            credentials: "include",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(fetchData)
        });
        const result = await response.json();
        return result;
    }
}
const watchArticle = new WatchArticle();
watchArticle.GetLikeOfArticle();
watchArticle.PostCommentUser("");
let dem = 0;
//click clap
clapBtn.addEventListener("click", async () => {
    dem++;
    clapNotification.innerHTML = "+" + dem;
    await watchArticle.RefreshArticleLikeProperty({ like: clapDecription.innerHTML, articleId: clapBtn.getAttribute("articleId").toString() });
    DisplayClapNotification();
})
function DisplayClapNotification() {
    showClapNotification.classList.add("show");
    if (setBox != null) {
        clearTimeout(setBox);
    }
    setBox = setTimeout(() => {
        clapCount = 0;
        showClapNotification.classList.remove("show");
    }, 2000);
}
// comment
commentField.addEventListener("change", async(e) => {
    const data = {
        comment: e.target.value,
        articleId: getUserId
    }
    if (e.target.value != "") {
        await watchArticle.PostCommentUser(data);
        e.target.value = '';
    }
})
/////
deleteNotification__BtnNode__cancel.addEventListener("click", async () => {
    blackFrame.classList.remove("showFrame");
})
deleteNotification__BtnNode__ok.addEventListener("click", async () => {
    if (getCommentId != "" && getCard != null) {
        var result = await watchArticle.DeleteComment(getCommentId);
        if (Object.keys(result).length > 0) {
            if (result.delete) {
                messageBox.removeChild(getCard);
                blackFrame.classList.remove("showFrame");
                const card = document.querySelectorAll(".peter");
                responses.innerHTML = "Responses (" + card.length + ")";
            }
        }
    }
})
editNotification_BtnNode_ok.addEventListener("click", async () => {
    const regex = RegExp(/([^>])/g);
    if (regex.test(editInput.value.trim())) {
        const data = {
            commentId: getCommentId,
            content: editInput.value
        }
        var result = await watchArticle.UpdateComment(data);
        if (result.update) {
            getChildComment.innerHTML = editInput.value;
            errorNone.classList.add("error-none");
            editFrame.classList.remove("showEditComment");
        }
    } else {
        errorNone.classList.remove("error-none");
    }
})
editNotification_BtnNode_cancel.addEventListener("click", async () => {
    editFrame.classList.remove("showEditComment");
})