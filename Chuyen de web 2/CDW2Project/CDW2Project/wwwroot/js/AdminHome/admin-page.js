$(document).ready(function () {
    $("#sidebarCollapse").on('click', function () {
        $("#sidebar").toggleClass("inactive"); 
    });

    const sidebar = document.getElementById("sidebar");
    const line100vw = document.getElementById("100vw");
    window.addEventListener("resize", function () {
        if (window.innerWidth <= 768) {
            sidebar.classList.add("inactive");
            line100vw.classList.add("line100vw");
        }
    });
    const delUser = document.getElementById("del-user");
    const hideNoti = document.getElementById("hide-noti")
    const noti = document.getElementById("noti-content");
    const modal__overlay = document.querySelector(".modal__overlay");
    const cancel_btn = document.getElementById("cancel-btn");
    const btnDelUser = document.querySelectorAll(".btn-delUser");
    const btnYes = document.querySelector(".btnYes");
    const items = document.querySelectorAll(".t-item");
    //deleted frame notification
    const deletedFrame = document.querySelector(".outSide-Frame");
    const messageFrame = document.querySelector(".deletedMessage-box .message");
    const deletedMessageBtn = document.querySelector(".deletedMessage-btn");
    //Delete button
    btnDelUser.forEach((value, index) => {
        value.addEventListener("click", async function () {
            hideNoti.style.display = "block";
            const userId = value.getAttribute("userId");
            btnYes.addEventListener("click", async () => {
                await DeleteUser(userId,index); 
                hideNoti.style.display = "none";
            });
        });
    });
    deletedMessageBtn.addEventListener("click", () => {
        deletedFrame.classList.remove("showDeletedFrame");
    })
    async function DeleteUser(userId, index) {
        const response = await fetch("/Admin/Home/DeleteUser/" + userId + "", {
            method: "POST",
            credentials: "include",
            headers: {
                'Content-Type': 'application/json'
            },
        }).catch(error => console.log(error));
        const result = await response.json();
        if (Object.keys(result).length > 0) {
            if (result.delete) {
                items[index].remove();
                messageFrame.innerHTML = result.message;
                deletedFrame.classList.add("showDeletedFrame");
            } else {
                messageFrame.innerHTML = result.message;
                deletedFrame.classList.add("showDeletedFrame"); 
            }
        }
    }
    cancel_btn.addEventListener("click", function () {
        hideNoti.style.display = "none";
    });
    modal__overlay.addEventListener("click", function () {
        hideNoti.style.display = "none";
    });
});