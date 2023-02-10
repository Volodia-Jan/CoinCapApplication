# CoinCap application
### About project:
It is a real-time parser of market activity from [CoinCap](https://docs.coincap.io/).
### Project tools:
* C# - to implement all server side logic
* WPF - to implement UI
### How does it work
When we open the application we can see main page - *Markets*. It sends HTTP request to get all markets and display them on the page as a list.
We can also click on each market to view detailed information on current market activity 
**Be careful, data is only available on Bibbox & Alterdice markets**
Moreover we have *Assets* page. On the left side we can see a list of available currencies. When we click on one of them - detailed information about this currency appears on the right side of page. During this it sends HTTP request to get that information.
Also on *Assets* page we have search feature. We can select the property to search (id or name) and fill the text box. This search is case-insensitive and looks for the field that **contains** the entered string.