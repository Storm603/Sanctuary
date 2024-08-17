/*animate__fadeInLeft*/
applyEventListenersToButtons();
function applyEventListenersToButtons() {
    let toSlideTwoButton = document.getElementById('toSlideTwo');
    let appScreenOne = document.getElementById('appScreenOne');
    let appScreenTwo = document.getElementById('appScreenTwo');
    let appScreenThree = document.getElementById('appScreenThree');

    let toSlideThreeButton = document.getElementById('toSlideThree');
    let backToSlideOneButton = document.getElementById('backToSlideOne');
    let backToSlideTwoButton = document.getElementById('backToSlideTwo');

    
    
    toSlideTwoButton.addEventListener("click", () => {

        appScreenOne.style.display = 'none';

        appScreenTwo.style.display = '';
    });

    toSlideThreeButton.addEventListener('click', () => {
        appScreenTwo.style.display = 'none';
        appScreenThree.style.display = '';
    })

    backToSlideOneButton.addEventListener('click', () => {
        appScreenTwo.style.display = 'none';
        appScreenOne.style.display = '';
    })

    backToSlideTwoButton.addEventListener('click', () => {
        appScreenThree.style.display = 'none';
        appScreenTwo.style.display = '';
    })
    let petSelectionDiv = document.getElementById('toSlideThree');

    
}

function slideInPanel() {
    let toSlideTwoButton = document.getElementById('toSlideTwo');
}

function slifeOutPanel(){ }