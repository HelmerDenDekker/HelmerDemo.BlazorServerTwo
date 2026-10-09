# MVU pattern

The MVU pattern structures the application in three main components:
- Model
- View
- Update

The model is an immutable record that holds the state.
The view is the UI-part.
The update is the logic that updates the model.

Another important part are the Messages. These are "commands" that are sent from the view to the update, to trigger an update of the model.

## Resources

[MVU in MAUI](https://en.ittrip.xyz/c-sharp/mvu-pattern-dotnet-maui)  
[MVU vs MVVM in Blazor](https://amarozka.dev/mvvm-vs-mvu-blazor-enterprise-state-pattern/)
