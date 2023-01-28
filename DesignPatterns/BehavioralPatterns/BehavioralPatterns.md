# Behavioral patterns

Behavioral patterns characterize complex control flow that's difficult to follow at runtime.


### Chain of Responsibility

Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request.
Chain the receiving objects and pass the request along the chain until an object handles it.

### Command

Encapsulate a request as an object, thereby letting you parameterize clients
with different requests, queue or log requests, and support undoable operations.
