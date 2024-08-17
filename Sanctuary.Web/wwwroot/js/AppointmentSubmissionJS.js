// !!!!!!!! REVIEW ALL CODE FOR THE CALENDAR AND IMPROVE IT FURTHER DOWN THE LINE !!!!!!!!

// Pop up day schedule after a calendar day select
var modalDaySchedule = new bootstrap.Modal(document.getElementById('dayScheduleModal'));

const monthNames = ["January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"];

////////// ASSIGNED 25 FOR TESTING PURPOSES
var totalAppointmentTimeMinutes = 25;
// Holds glowing TD elements belonging to the day schedule structure
var elGlowCollection = [];
var elGlowSelectedCollection = [];

// Used to reapply values to the global month and year variables for when a new callendar instance is created
var reapplyCalendarValuesAndGenerateCalendar = function () {
    var date = new Date();
    year = date.getFullYear();
    // months are zero index based
    month = date.getMonth();

    generateCalendar(month, year)
}

// use daysInMonth and indexedFirstDayOfMonth to set calendar up
// gets all days in a month
var daysInMonth = function (year, month) {
    return new Date(year, month + 1, 0).getDate();
}

// Main calendar values
var year = '';
var month = '';

let calendarLeftArrow = document.getElementById('calendarButtonArrowLeft');
let calendarRightArrow = document.getElementById('calendarButtonArrowRight');

calendarLeftArrow.addEventListener('click', () => {
    month--;
    if (month < 0) {
        year--;
        month = 11;
    }

    generateCalendar(month, year);
});

calendarRightArrow.addEventListener('click', () => {
    month++;
    if (month > 11) {
        year++;
        month = 0;
    }

    generateCalendar(month, year);
});

var generateCalendar = function (month, year) {
    // gets Sunday(0) to saturday(6) indexed days of the week, use to navigate and populate the calendar accurately from the specific day
    // gets the day of the week as an index
    let indexedFirstDayOfMonth = new Date(year, month, 1).getDay();

    let lastMonthDays = daysInMonth(year, month - 1) - (indexedFirstDayOfMonth - 2);

    // sets calendar month
    let calendarMonthElement = document.getElementById('current-month-information');
    calendarMonthElement.innerHTML = `${monthNames[month]} - ${year}`;

    // calls the function to retrieve all days in the current month
    let daysInCurrentMonth = daysInMonth(year, month);

    let calendarMonthTBody = document.querySelector(`[data-calendar-id=calendar-month-days]`);
    calendarMonthTBody.innerHTML = '';

    // Creates first week to append to calendar
    let trWeek = document.createElement('tr');
    trWeek.className = 'calendar-first-week';

    // Calendar day counter
    let count = 0;
    let tdDay = document.createElement('td');

    // First cycle populates week one
    for (var i = 1; i <= 7; i++) {
        // Will enter if first day of current month is Sunday
        if (indexedFirstDayOfMonth == 0) {
            tdDay.textContent = lastMonthDays++;
            tdDay.className = 'inactive-calendar-day';

            if (i == 7) {
                tdDay.textContent = ++count;
                tdDay.className = 'active-calendar-day';

            }
        }
        else if (i >= indexedFirstDayOfMonth) {
            tdDay.textContent = ++count;
            tdDay.className = 'active-calendar-day';
            tdDay.setAttribute('data-hidden-value', `${year}.${month + 1}.0${tdDay.innerText}`);
        }
        else {
            tdDay.textContent = lastMonthDays++;
            tdDay.className = 'inactive-calendar-day';
        }

        trWeek.appendChild(tdDay);
        tdDay = document.createElement('td');
    }

    calendarMonthTBody.appendChild(trWeek);

    trWeek = document.createElement('tr');
    trWeek.className = 'calendar-week';

    // second loop populates all month days minus the days from the first week
    for (var i = 1; i <= daysInCurrentMonth - count; i++) {
        tdDay = document.createElement('td');
        tdDay.className = 'active-calendar-day';

        // date formatted acording to the international standard YYYY-MM-DD, month has +1 value added to it because the Date object indexes them starting from 0
        tdDay.setAttribute('data-hidden-value', `${year}.${month + 1}.${i + count < 10 ? `0${i + count}` : i + count}`);

        // function creating internal elements and attaching them to the td
        populateCalendarDayLayout(i + count, tdDay);

        trWeek.appendChild(tdDay);

        // this creates and appends new week every SUNDAY
        if (i % 7 == 0) {
            calendarMonthTBody.appendChild(trWeek);

            // checks for last month day to append the unique class name
            if (i == daysInCurrentMonth - count) {
                trWeek.className = 'calendar-last-week'
                break;
            }

            trWeek = document.createElement('tr');
            trWeek.className = 'calendar-week';
        }
        // this is the LAST week append check - it appends the current created week and appends it to the table body if the index of the loop is the last day of the month
        else if (i % 7 != 0 && i == daysInCurrentMonth - count) {
            calendarMonthTBody.appendChild(trWeek);
            trWeek.className = 'calendar-last-week'
        }
    }

    let lastWeekEmptyCellsCount = trWeek.childElementCount;

    for (var i = 1; i <= 7 - lastWeekEmptyCellsCount; i++) {
        tdDay = document.createElement('td');
        tdDay.className = 'inactive-calendar-day';
        tdDay.textContent = i;
        trWeek.appendChild(tdDay);
    }

    calendarMonthTBody.addEventListener('click', (event) => {
        if (event.target.classList.contains('active-calendar-day')) {
            let dayNumber = event.target.getAttribute('data-hidden-value').slice(-2);

            modalDaySchedule.toggle();

            repopulateDayScheduleIndication(dayNumber);
        }
    });
};

// Retrieves new information for reserved time frames and refreshes the day schedule
function repopulateDayScheduleIndication(dayNumber) {
    let dayScheduleDayIndicator = document.getElementById('dayScheduleDayIndicator');

    dayScheduleDayIndicator.textContent = `${dayNumber}.${month}.${year}`;

    $.ajax(
        {
            url: 'https://localhost:7253/GetAppointmentTimeFrames/',
            type: 'GET',
            headers: { day: `${dayNumber}`, vetId: 'c1f4eece-e448-40a6-8ce0-b2d7e823c7c5' }, // test data set on vetId
            dataType: 'json',
            success: function (incomingData) {
                console.log(incomingData);
                let hourSchedule = document.getElementById('hourSchedule');
                let count = 0;

                for (var i = 0; i < hourSchedule.childNodes.length - 1; i++) {
                    let element = hourSchedule.childNodes[i];

                    element.classList = '';

                    if (incomingData.length != 0) {

                        if (element.getAttribute('time') == incomingData[count].Item1.slice(0, 5)) {

                            for (var j = 0; j < incomingData[count].Item2; j++) {
                                element = hourSchedule.childNodes[i++];
                                element.classList = 'appointmentGlowUpReserved';
                            }

                            count++;

                            if (count == incomingData.length) {
                                count = 0;
                            }
                        }
                    }

                }
            },
            error: function (error) { console.log(error.responseText) }
        })
};

function populateCalendarDayLayout(day, tdDay) {
    let divHolder = document.createElement('div');
    divHolder.className = ' align-items-start';
    divHolder.style = 'pointer-events: none;';

    // day number holder
    let dayNumber = document.createElement('span');
    dayNumber.textContent = day;
    dayNumber.classList = 'align-self-start';

    divHolder.appendChild(dayNumber);

    tdDay.appendChild(divHolder);
}


// Generates day schedule HTML structure and applies basic CSS classes
function generateDayScheduleStructure() {
    let trBodySchedule = document.getElementById('hourSchedule');

    let hourCounter = 8;
    let cycleCount = 0;

    while (cycleCount < 8) {
        if (cycleCount == 4) {
            let fiveMinuteInterval = document.createElement('td');
            fiveMinuteInterval.setAttribute('lunch-break', `${hourCounter < 10 ? `0${hourCounter}` : hourCounter}:00`);
            trBodySchedule.appendChild(fiveMinuteInterval);
            hourCounter++;
        }
        for (var i = 0; i < 12; i++) {
            let fiveMinuteInterval = document.createElement('td');
            fiveMinuteInterval.setAttribute('time', `${hourCounter < 10 ? `0${hourCounter}` : hourCounter}:${i < 2 ? `0${i * 5}` : i * 5}`);

            trBodySchedule.appendChild(fiveMinuteInterval);
        }

        cycleCount++;
        hourCounter++;
    }

    let timeHourInputElement = document.getElementById('hour');
    let timeMinuteInputElement = document.getElementById('minute');

    let hourTo = document.getElementById('hourTo');
    let minuteTo = document.getElementById('minuteTo');

    // Applies functionality to TD elements
    ApplyTimeFrameGlowUp(trBodySchedule, totalAppointmentTimeMinutes, timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo);
    // Applies functionality to BUTTON elements
    TimeButtonsConfiguration(totalAppointmentTimeMinutes, timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo);
};

// Applies two event listeners for 'mouseover' and 'mouseout' which will add and remove the CSS class that lights up the background-color of the elements
function ApplyTimeFrameGlowUp(trBodySchedule, totalAppointmentTimeMinutes, timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo) {
    trBodySchedule.addEventListener('mouseover', (event) => {
        if (event.target.hasAttribute('time')) {
            tDGlowUp(event, totalAppointmentTimeMinutes, timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo);
        }
    });

    let errorMsgNotif = document.getElementById('errorMessageNotification');
    let msgNotif = document.getElementById('messageNotification');
    
    let daySchedulePopUp = document.getElementById('daySchedulePopUp');
    let daySchedulePanel = document.getElementById('daySchedulePanel');
    let declineButton = document.getElementById('declineDayScheduleButton');

    trBodySchedule.addEventListener('click', (event) => {
        errorMsgNotif.style.display = 'none';
        msgNotif.style.display = 'none';

        daySchedulePanel.style.filter = `blur(0px)`;

        let tdElement = event.target;

        let containsError = false;

        for (var i = 0; i < elGlowCollection.length - 1; i++) {
            if (elGlowCollection[i].classList.contains('appointmentGlowUpReserved')) {
                containsError = true;
                break;
            }
        }

        if (tdElement.classList.contains('appointmentGlowUpReserved') || containsError) {
            errorMsgNotif.style.display = 'block';
            errorMsgNotif.textContent = 'You cannot book an appointment at this time.';
        }
        else if (tdElement.getAttribute('lunch-break') != null || (hourTo.value == '12' && hourTo.classList.contains('timePickerError'))) {
            errorMsgNotif.style.display = 'block';
            errorMsgNotif.textContent = 'You cannot book an appointment during lunch break hours.';
        }
        else if (hourTo.value == '17' && hourTo.classList.contains('timePickerError')) {
            errorMsgNotif.style.display = 'block';
            errorMsgNotif.textContent = 'You cannot book an appointment during closing hours.';
        }
        else if (tdElement.getAttribute('time') != null) {
            daySchedulePanel.style.filter = `blur(4px)`;
            daySchedulePopUp.classList.add('deactivatePointer');

            elGlowSelectedCollection.forEach((x) => {
                x.classList.remove('appointmentGlowUpSelected');
            })

            elGlowSelectedCollection = [];

            elGlowCollection.forEach((x) => {
                x.classList.add('appointmentGlowUpSelected')
                elGlowSelectedCollection.push(x);
            });
            msgNotif.style.display = 'block';
            msgNotif.textContent = `You have selected the time frame FROM - ${timeHourInputElement.value}:${timeMinuteInputElement.value} TO - ${hourTo.value}:${minuteTo.value}. Please confirm your selection or decline it to select a different time frame!`;
        }
    });

    declineButton.addEventListener('click', (event) => {
        msgNotif.style.display = 'none';

        daySchedulePanel.style.filter = `blur(0px)`;
        daySchedulePopUp.classList.remove('deactivatePointer');

        elGlowSelectedCollection.forEach((x) => {
            x.classList.remove('appointmentGlowUpSelected');
        })

        elGlowSelectedCollection = [];
    })
}


// Glow up functionality
function tDGlowUp(event, totalAppointmentTimeMinutes, timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo) {
    let elementsToBeAfectedByGlowUp = totalAppointmentTimeMinutes / 5;

    let timeHour = '';
    let timeMinute = '';

    // Checks wether the event comes from a mouseover TD element or the buttons attached to the day schedule modal
    if (event.target.tagName == 'TD') {
        timeHour = event.target.getAttribute('time').split(':')[0];
        timeMinute = event.target.getAttribute('time').split(':')[1];

        timeHourInputElement.value = timeHour;
        timeMinuteInputElement.value = timeMinute;
    }
    else if (event.target.tagName == 'BUTTON') {
        timeHour = timeHourInputElement.value;
        timeMinute = timeMinuteInputElement.value;
    }

    timeHourInputElement.classList.remove('timePickerError');
    timeMinuteInputElement.classList.remove('timePickerError');
    timeHourInputElement.classList.add('timePickerNormal');
    timeMinuteInputElement.classList.add('timePickerNormal');

    hourTo.classList.remove('timePickerError');
    minuteTo.classList.remove('timePickerError');
    hourTo.classList.add('timePickerNormal');
    minuteTo.classList.add('timePickerNormal');

    removalOfGlowUpCSSClassesLoop();

    let elGlow = '';

    if (event.target.tagName == 'TD') {
        elGlow = event.target;
    }
    else if (event.target.tagName == 'BUTTON') {
        elGlow = document.querySelector(`[time='${timeHour}:${timeMinute}']`);
    }

    let reservedAppointmentFlag = false;

    for (var i = 0; i < elementsToBeAfectedByGlowUp; i++) {
        // Condition: Assigns red colour to the selected time intervals if any of the conditions are met
        if (elGlow == null) {
            ReplaceGlowUpErrorClasses(timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo);

            hourTo.value = '17';
            minuteTo.value = '00';
            return;
        }
        else if (elGlow.classList.contains('appointmentGlowUpReserved') && i == 0) {
            hourTo.value = '';
            minuteTo.value = '';

            ReplaceGlowUpErrorClasses(timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo);

            return;
        }
        else if (elGlow.hasAttribute('lunch-break')) {
            ReplaceGlowUpErrorClasses(timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo);

            hourTo.value = '12';
            minuteTo.value = '00';
            return;
        }
        else if (elGlow.classList.contains('appointmentGlowUpReserved') && !reservedAppointmentFlag) {
            reservedAppointmentFlag = true;
        }

        elGlow.classList.add('appointmentGlowUp');
        elGlowCollection.push(elGlow);

        // overwriting elGlow html element
        elGlow = elGlow.nextSibling;

        if (i == elementsToBeAfectedByGlowUp - 1) {
            if (elGlow == null) {
                hourTo.value = '17';
                minuteTo.value = '00';
                return;
            }
            else if (elGlow.hasAttribute('lunch-break')) {
                hourTo.value = '12';
                minuteTo.value = '00';
                return;
            }

            let timeSplit = elGlow.getAttribute('time').split(':');
            hourTo.value = timeSplit[0];
            minuteTo.value = timeSplit[1];

            if (reservedAppointmentFlag) {
                ReplaceGlowUpErrorClasses(timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo);
            }
        }
    }
}

// Replaces glow CSS classes from normal to error types
// Elements to be changed are held in a global array - elGlowCollection
function ReplaceGlowUpErrorClasses(timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo) {
    for (var i = 0; i < elGlowCollection.length; i++) {

        elGlowCollection[i].classList.remove('appointmentGlowUp');
        elGlowCollection[i].classList.add('appointmentGlowUpError');
    }
    timeHourInputElement.classList.remove('timePickerNormal');
    timeMinuteInputElement.classList.remove('timePickerNormal');
    timeHourInputElement.classList.add('timePickerError');
    timeMinuteInputElement.classList.add('timePickerError');

    hourTo.classList.remove('timePickerNormal');
    minuteTo.classList.remove('timePickerNormal');
    hourTo.classList.add('timePickerError');
    minuteTo.classList.add('timePickerError');
}

// Static variables holding necessary values for time manipulation
const HourContainer = ["08", "09", "10", "11", "13", "14", "15", "16"];
const MinuteContainer = ["00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"];

// Applies listeners to the buttons attached to the day schedule structure that control the time of the appointment
function TimeButtonsConfiguration(totalAppointmentTimeMinutes, timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo) {
    let arrowButtons = Array.from(document.getElementsByClassName('timeControls'));

    arrowButtons.forEach((elem) => {
        elem.addEventListener('click', (event) => {

            let hourIndex = HourContainer.indexOf(timeHourInputElement.value);
            let minuteIndex = MinuteContainer.indexOf(timeMinuteInputElement.value);

            switch (event.target.id) {
                case 'arrowHourUp':
                    timeHourInputElement.value = ValidateAndReturnArrayValue(HourContainer, ++hourIndex);
                    break;
                case 'arrowHourDown':
                    timeHourInputElement.value = ValidateAndReturnArrayValue(HourContainer, --hourIndex);
                    break;
                case 'arrowMinuteUp':
                    timeMinuteInputElement.value = ValidateAndReturnArrayValue(MinuteContainer, ++minuteIndex);
                    break;
                case 'arrowMinuteDown':
                    timeMinuteInputElement.value = ValidateAndReturnArrayValue(MinuteContainer, --minuteIndex);
                    break;
                default:
            }

            tDGlowUp(event, totalAppointmentTimeMinutes, timeHourInputElement, timeMinuteInputElement, hourTo, minuteTo);
        });
    });
};

// Chooses the appropriate index according to the parameters from the arrays "hourContainer", "minuteContainer" and returns the value from it
function ValidateAndReturnArrayValue(array, index) {
    if (array.length == index) {
        return array[0];
    }
    else if (index < 0) {
        return array[array.length - 1]
    }
    else {
        return array[index];
    }
};


// removes all glow up CSS classes from the TD elements in the day schedule table
// Explanation: the TD elements that have glow up classes are kept in a global array, every time an event is fired the elements are taken from the array and the classes are removed, afterwards
// the array is flushed
function removalOfGlowUpCSSClassesLoop() {
    for (var i = 0; i < elGlowCollection.length; i++) {
        elGlowCollection[i].classList.remove('appointmentGlowUp');
        elGlowCollection[i].classList.remove('appointmentGlowUpError');
    }

    elGlowCollection = [];
}

// Applies global year and month values AND calls the 'generateCallendar' function
reapplyCalendarValuesAndGenerateCalendar();

// Creates callendar
//generateCalendar(month, year);

// Creates the day schedule basic structure and applies CSS classes
generateDayScheduleStructure();

var currentShownElement = ''

let vetSelectionConfiguring = function () {
    let elementToShow = document.querySelector(`[data-list-id=vetInfo-0]`);
    let nameList = document.getElementById('vetList');

    currentShownElement = elementToShow;

    if (elementToShow != null) {
        elementToShow.style.display = 'flex';
    }

    nameList.addEventListener('click', (event) => {
        if (event.target.tagName == 'LI') {
            if (event.target == currentShownElement) {
                return;
            }

            let elementId = document.querySelector(`[data-list-id=${event.target.id}]`);

            console.log(elementId);
            currentShownElement.style.display = 'none';
            currentShownElement = elementId;
            currentShownElement.style.display = 'flex';

            reapplyCalendarValuesAndGenerateCalendar();
        }
    });
}

vetSelectionConfiguring();