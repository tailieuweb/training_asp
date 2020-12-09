$(document).ready(() => {
    var data = {

    }
    //create class Home
    class Home {
        constructor() {
            
        };
    }
    var home = new Home();
    console.log(home.name)
    //add "programing_active" class for items
    var programingItem = document.querySelectorAll(".new__right__box__item");
    programingItem.forEach((value, index) => {
        value.addEventListener("click", () => {
            deleteProgramingActive();
            value.classList.add("programing_active");
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
})