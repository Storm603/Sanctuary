var zipCodeInputField = document.querySelector("#zipCodeInput");
const variable = document.querySelector("#dropdownItems");

zipCodeInputField.addEventListener("change", () => {

    if (/*!variable.classList.contains('show') && */zipCodeInputField.innerHTML.trim() != '' || zipCodeInputField.innerHTML.trim() != null) {
        variable.classList.add('#show')
        return
    }
    else {
        variable.classList.remove('#show');
        return
 }
});

document.querySelector('#hi').style.backgroundColor = "red";