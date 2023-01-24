# AMP 2023

I will use this repository as a central location for collecting and organizing all the ideas and materials related to my project as part of Omegapoint's Academy Masters Program 2023.

# Design Patterns as a First Line of Defence

## Description

Design patterns are reusable solutions to common problems that arise during software development. 
I will explore if design patterns can help developers not only to solve these common problems, but without introducing security vulnerabilities in their code. 
By incorporating Secure by Design principles while exploring these patterns I hope to find some insight how one can argue why design patterns is your first line of defence. 

Additionally, I want to learn which patterns are more suitable for specific problems.

_Hur kan design patterns hjälpa överlag med hur team levererar idag. Vad är det?_ 

### Principles in code that design patterns embrace that can improve security

- Loose coupling 
    - Chain of Responsibility, Command, Mediator, and Observer patterns, promote loose coupling between objects, making it more difficult for an attacker to exploit dependencies and gain unauthorized access to sensitive data.
- DRY - Don't Repeat Yourself - ...
- Immutability - immutable object are safe to share between threads and open up high data availability - an important aspect of denial of service attacks - Builder pattern

- The Singleton pattern can be used to ensure that only one instance of a class is created, this can be useful in managing resources that need to be shared across an application and preventing unauthorized instantiation of a class.

### Goals

- Create the course Design Patterns 101

- Competence-day presentation
- OpKoKo talk
- Presentation on external event

## Pitch

Design patterns are a powerful tool that can help improve the security of your codebase. Some patterns promote loose coupling, others limit instantiation of classes or create secure objects by incorporating secure by design principles. By using design patterns as a first line of defense in your codebase, you can improve the overall security of your codebase and reduce the risk of vulnerabilities.