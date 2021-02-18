Feature: Feature876_PBI576_UpdateFirstNameInAccount
	

@smoke
Scenario: Update first name in the account page
	Given the applicaiton is launched
	And i login to the application
	And i validate home page
	Then i update first name and save
	|  name|
	|  newtest |
	