# MVC-like Example

This is just an old-fashioned example of having the front-end separate from the API-Backend. A bit like MVC: Model-View-Controller.

So every time the user want to submit data, you have to do this explicit commit to the backend.  
The backend stores, asynchronously in reality, not in this example.

I did clarify the boundaries between the projects, by having clear DTO's and objects for all the layers. Your Database-persistence layer may have DAO's.  
This leads to an extreme amount of adapters, but it is also extremely decoupled.

NB! Decoupled in TIME AND SPACE! You can swap the application for another.

## Explained

### ViewState.  
The ViewState is clearly the state that the user sees in the tab that is open. It is the state of the page in the session you are working in.  

I want it to be clear, that the ViewState here is only to be manipulated by the user. Only when the user refreshes, the page is reloaded and new information shown.

In Blazor it is a bit more complex in reality, because the HTML exists in the browser, and has a state that is continuously synchronized to the server over a websocket connection.  
So, the ViewState does not HAVE to be the same as the HTML page, we just have to trust Blazor to do its magic.

### Service
The Service is the controller of the page in MVC. It validates and orchestrates. It has a clear boundary defined by the service interface and the data transfer objects (DTO's).

### Domain
The Model, but unlike MVC, where there are aenemic models and the business logic is kept separate, this is more like a Domain model.  
This is where the business logic lives.   
The domain model is the single source of truth. 




