---
description: 'Blazor component and application patterns'
applyTo: '**/*.razor, **/*.razor.cs'
---

## Blazor code style and instructions

- Write idiomatic and efficient Blazor and C# code.
- Follow .NET and Blazor conventions.
- Use Razor components appropriately for component-based UI development.
- Use the razor code-behind file for UI-related logic only
- Separate business logic and data access into services or other appropriate layers, depending on the architectural pattern used.
- Use dependency injection to manage services and promote testability.

## Naming conventions

- Use PascalCase for component names, class names, method names, and public members.
- Use camelCase for private fields and local variables.
- Prefix interface names with "I" (e.g., `IService`).

## Error handling and Validation

- Implement proper error handling and validation in components and services.
- Use try-catch blocks where appropriate and provide meaningful error messages.
- Use logging for error tracking in the backend, and consider capturing UI-level errors in Blazor with tools like ErrorBoundary.
- For validation, use DataAnnotations.

## Blazor API and Performance optimization

- Utilize Blazor server-side for this demo project only.
- Optimize component rendering and minimize unnecessary re-renders to improve performance.
- Minimize the component render tree by avoiding re-rendering unless necessary, using ShouldRender() where appropriate.