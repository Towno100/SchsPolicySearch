# SchsPolicySearch

## Approach
I decided to use this coding challenge to try out .NET 6 Web Api with a separate Front End SPA application. In addition, I wanted to try out mapping Domain Drive Design value objects 
to a db, and an In-Memory implementation of EF Core.

In terms of code. The Web Api is very simple. It takes in the two parameters and then uses the ISearchService to locate the policy. Data persistence is with an InMemory implementation 
of EF Core. Only the first 10 records from the sample data are loaded and searchable.

## Limitations/Omissions
Due to trying out some new concepts I have burnt through the allocated time. Improvements I would make are the following:
- Add unit tests
- Validation of inputs and useful validation messages for users on the front end
- Rework of the domain. I suspect the real business domain is that a user may have more than one policy, so in actual fact there is a one to many relationship between the user and policies
- Bug fixes - If a user were to search for a policy number of one user and the member number of another the api would simply return the first member found
- Styling of the SPA application

## Instructions to run
- Download the code
- Build (Recommend Visual Studio 2022, not sure if this will work with Visual Studio 2019)
- You may need to run npm install
- Setup multiple startup projects - SchsPolicySearch.Web and SchsPolicySearch.FrontEnd
- Run the application
- There is a bug in the application - Be sure to include values in both inputs before clicking search
