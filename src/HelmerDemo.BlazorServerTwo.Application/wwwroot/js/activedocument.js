let state, visibilityChange;
if (typeof document.hidden !== "undefined") {
    visibilityChange = "visibilitychange";
    state = "visibilityState";
} else if (typeof document.mozHidden !== "undefined") {
    visibilityChange = "mozvisibilitychange";
    state = "mozVisibilityState";
} else if (typeof document.msHidden !== "undefined") {
    visibilityChange = "msvisibilitychange";
    state = "msVisibilityState";
} else if (typeof document.webkitHidden !== "undefined") {
    visibilityChange = "webkitvisibilitychange";
    state = "webkitVisibilityState";
}

// Add a listener that constantly changes the title
document.addEventListener(visibilityChange, function () {
    document.title = document[state];
    activeDocumentReceivers.forEach(rec => rec.invokeMethodAsync("ActiveDocumentState", document[state]));
}, false);

// Set the initial value
document.title = document[state];


let activeDocumentReceivers = [];

export function registerActiveDocumentReceiver(receiver) {
    activeDocumentReceivers.push(receiver);
}