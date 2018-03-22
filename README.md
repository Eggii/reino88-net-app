# Simple Asp.Net website

Task was to make two aspx pages which display all the information from attached xml files according to wireframes. 

## Required Technologies

- C#
- .Net
- XML
- Linq
- jQuery

## Built With

-   [Visual Studio 2017](https://www.visualstudio.com/downloads/) 
    - [Visual Studio 2017 Product Family System Requirements](https://docs.microsoft.com/en-us/visualstudio/productinfo/vs2017-system-requirements-vs)

## Installing

You should have installed Visual Studio 2017. Depending on your machine you may need to do some extra steps.

##Deployment

## Task
First page list.aspx should display all the information from list.xml and availability from details.xml. Allow client side product block sorting with jquery by price and popularity in both ascending and descending direction. List page has to remember sorting type and direction if user is browsing between list and details page. Products availability must be retrieved with ajax call(s) from second page.
Second page should display product details from list.xml and detail.xml, fields needed are shown on the wireframe. For second page product data is in detail.xml except price which has to be retrieved with LINQ join query from list.xml. Second page must have one .net webmethod returning products availability as a json object for list page.

Products in xml’s are linked by Product node attribute id 

## Result
Visual studio ASP.NET Web Application project containing at least two aspx web pages able to read information from data xml files and display it according to wireframes over http protocol. 

## Author

Reino Veskimäe

## Licence
[Attribution-NoDerivatives 4.0 International  (CC BY-ND 4.0)](https://creativecommons.org/licenses/by-nd/4.0/legalcode)# ADM_App
