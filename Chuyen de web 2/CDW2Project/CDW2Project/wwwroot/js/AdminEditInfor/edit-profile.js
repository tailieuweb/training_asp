$(document).ready(function () {
    const btnYes = document.querySelector(".btn -yes");
    const delPost = document.getElementById("del-post");
    const hideNoti = document.getElementById("hide-noti")
    const noti = document.getElementById("noti-content");
    const modal__overlay = document.querySelector(".modal__overlay");
    const cancel_btn = document.getElementById("cancel-btn");
    const sidebar = document.getElementById("sidebar");
    const line100vw = document.getElementById("100vw");
    const actionsDel = document.querySelectorAll(".actions__del");
    //Upload image 
    const changeAvt = document.getElementById('change-avt');
    const avatar = document.querySelector(".avatar");
    //Get userId on browser 
    const getBrowseUrl = window.location.href;
    const browseUrlArr = getBrowseUrl.split("/");
    const getUserId = browseUrlArr[browseUrlArr.length - 1];
    //deleted frame notification
    const deletedFrame = document.querySelector(".outSide-Frame");
    const messageFrame = document.querySelector(".deletedMessage-box .message");
    const deletedMessageBtn = document.querySelector(".deletedMessage-btn");
    const deleteArticleBtn = document.querySelector(".deleteArticle-Btn");
    const articleItems = document.querySelectorAll(".articleItem");
    $("#sidebarCollapse").on('click', function () {
        $("#sidebar").toggleClass("inactive"); 
    });
    window.addEventListener("resize", function () {
        if (window.innerWidth <= 768) {
            sidebar.classList.add("inactive");
            line100vw.classList.add("line100vw");
        }
    });
    delPost.addEventListener("click", function () {
        hideNoti.style.display = "block";
    });

    cancel_btn.addEventListener("click", function () {
        hideNoti.style.display = "none";
    });
    modal__overlay.addEventListener("click", function () {
        hideNoti.style.display = "none";
    });
    deletedMessageBtn.addEventListener("click", () => {
        deletedFrame.classList.remove("showDeletedFrame");
    })
    changeAvt.addEventListener("change", async function () {
        const file = this.files[0];
        if (file)
        {
            const reader = new FileReader();
            reader.addEventListener("load", function () {
                avatar.setAttribute("src", this.result);
            });
            reader.readAsDataURL(file);
            var formData = new FormData();
            formData.append('model.file', file);
            formData.append('model.userid', getUserId);
            await UpdateImageUser(formData);
        }
    })
    async function UpdateImageUser(data) {
        const reponse = await fetch("/Admin/EditInfor/UploadPersonalImage", {
            method: "POST",
            credentials: "include",
            body: data
        });
        const result = await reponse.json();
        if (Object.keys(result).length > 0) {
            if (result.update) {
                messageFrame.innerHTML = result.message;
                deletedFrame.classList.add("showDeletedFrame");
            } else {
                messageFrame.innerHTML = result.message;
                deletedFrame.classList.add("showDeletedFrame");
            }
        }
    }
    //Delete article 
    actionsDel.forEach((value, index) => {
        value.addEventListener("click", async () => {
            hideNoti.style.display = "block";
            deleteArticleBtn.addEventListener("click", async () => {
                hideNoti.style.display = "none";
                const articleId = value.getAttribute("articleId");
                await DeleteArticle(articleId,index);
            })
        })
    })
    async function DeleteArticle(articleId,index) {
        const response = await fetch("/Admin/EditInfor/DeleteArticle/" + articleId + "", {
            method: "POST",
            credentials: "include",
            headers: {
                'Content-Type': 'application/json'
            },
        }).catch(error => console.log(error));
        const result = await response.json();
        if (result.delete) {
            messageFrame.innerHTML = result.message;
            articleItems[index].remove();
            deletedFrame.classList.add("showDeletedFrame");
        } else {
            messageFrame.innerHTML = result.message;
            deletedFrame.classList.add("showDeletedFrame");
        }
    }
});