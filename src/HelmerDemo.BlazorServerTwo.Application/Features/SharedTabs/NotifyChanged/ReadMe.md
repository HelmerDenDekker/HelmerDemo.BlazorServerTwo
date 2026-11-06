# INotifyPropertyChanged

I cannot use it here, because:
- When the user types, the EditMessageViewModel MessageFormText will be changed by the Blazor View
- I want the state to be notified about this change, so I need to use the INotifyPropertyChanged interface to command the state to change the MessageFormText property.
- The problem is that this changes the MessageFormText property in MessageBoxState, upon which the EditMessageViewModel is subscribed.
- So, the EditMessageViewModel will be notified about the change in MessageFormText, and it will update its own MessageFormText property, which will cause the Blazor View to update the input field.
- While in this process, the user is typing, causing the app to crash, because it is continuously changing the values.

Whatever the solution you choose, the active tab cannot have the subscription.

## Edit mode in active browser tab

This could be solved with an EditMode, allowed for one tab, but this makes it VERY complex!

The only way to correctly solve this, is in the browser.

``` javascript
let hidden, state, visibilityChange;
if (typeof document.hidden !== "undefined") {
hidden = "hidden";
visibilityChange = "visibilitychange";
state = "visibilityState";
} else if (typeof document.mozHidden !== "undefined") {
hidden = "mozHidden";
visibilityChange = "mozvisibilitychange";
state = "mozVisibilityState";
} else if (typeof document.msHidden !== "undefined") {
hidden = "msHidden";
visibilityChange = "msvisibilitychange";
state = "msVisibilityState";
} else if (typeof document.webkitHidden !== "undefined") {
hidden = "webkitHidden";
visibilityChange = "webkitvisibilitychange";
state = "webkitVisibilityState";
}

// Add a listener that constantly changes the title
document.addEventListener(visibilityChange, function() {
document.title = document[state];
}, false);

// Set the initial value
document.title = document[state];

```

by David Walsh [Page Visibility API](https://davidwalsh.name/page-visibility)


## Solution: Typing State / something like that as in the Chat app.

Update the backend periodically. Create a stream using RX. While the tab is active AND the user is typing.

## What if I have two active windows?

The only way to correctly sync this is in the browser, but what is the best way?  
The whole point of this was to easily sync data in multiple tabs. This is not easy for fields with user input.  

I think I will abandon this for now.
