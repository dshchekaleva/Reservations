function init(dotNetReference) {
var calendarEl = document.getElementById('calendar');
var calendar = new FullCalendar.Calendar(calendarEl, {
events: function (info, successCallback) {
dotNetReference.invokeMethodAsync('GetEvents',info.start, info.end).then((events) => {
successCallback(events)}) },
editable: true,
selectable: true,
initialView: 'dayGridMonth',
dateClick: function (info) {
dotNetReference.invokeMethodAsync('CalendarSellClicked', info.dateStr);
},
eventClick: function(info) {
dotNetReference.invokeMethodAsync('CalendarEventClicked', info.event.extendedProps.identifier);
}
//datesSet: event => {
//var month = new Date((event.start.getTime() + event.end.getTime()) / 2).getMonth() + 1;
//doSomethingOnThisMonth(month, calendar);
//}
});
calendar.render();
}

function initShow(dotNetReference) {
var calendarEl = document.getElementById('calendar');
var calendar = new FullCalendar.Calendar(calendarEl, {
events: function (info, successCallback) {
dotNetReference.invokeMethodAsync('GetEvents', info.start, info.end).then((events) => {
successCallback(events)
})
},
editable: true,
selectable: true,
initialView: 'dayGridMonth',
});
calendar.render();
}

function showPopup(element) {
return element.showModal();
}

function closePopup(element) {
return element.close();
}

//function hidePopup(element) {
//return element.close();
//}

//function addEventToCalendar(event) {
//var calendarEl = document.getElementById('calendar');
//calendarEl.addEvent(event);
//}

function showSucess() {
alert('Termín rezervován, děkujeme');
}

