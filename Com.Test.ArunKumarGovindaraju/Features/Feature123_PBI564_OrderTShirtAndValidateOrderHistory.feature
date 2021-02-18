Feature: Feature123_PBI564_OrderTShirtAndValidateOrderHistory
	

@smoke
Scenario: Place T Shirt Order
	Given the applicaiton is launched
	And i login to the application
	And i validate home page
	And i Click on TShirts tab
	And i select the first product and add to cart 
	And i Validate Summary, Address, Shipping  and payment tabs
	Then i confirm the order 
	Then  i validate the order in order history tab