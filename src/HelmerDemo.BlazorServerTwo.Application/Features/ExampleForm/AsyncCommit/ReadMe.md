# Async Commit Example

This is just an old-fashioned example of having the front-end separate from the API-Backend.

So every time the user want to submit data, you have to do this explicit commit to the backend.  
The backend stores, asynchronously in reality, not in this example.

I did clarify the boundaries between the projects, by having clear DTO's and objects for all the layers. Your Database-persistence layer may have DAO's.  
This leads to an extreme amount of adapters, but it is also extremely decoupled.

NB! Decoupled in TIME AND SPACE! You can swap the application for another.


