const iconField = document.getElementById("icon-Field");
const btnCheckIcon = document.querySelector(".btn-checkIcon");
const iconCheckedFrame = document.querySelector(".icon-checkedFrame");
const iconError = document.querySelector(".iconError");
const frm = document.querySelector(".frm");
btnCheckIcon.addEventListener("click", () => {
    checkIconFormat();
})
frm.addEventListener("submit", (e) => {
    const result = checkIconFormat();
    if (result === false) {
        e.preventDefault();
    } else {
        return true;
    }
})
function checkIconFormat() {
    if (iconField.value != "" && /(<(i class=+[^>]+)>+<[i/]+>)/g.test(iconField.value)) {
        iconCheckedFrame.innerHTML = iconField.value;
        iconError.innerHTML = '';
        return true;
    } else {
        iconError.innerHTML = "Enter need to right icon format";
        return false;
    }
}