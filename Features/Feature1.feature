Feature: Shop Items

Background: 
	Given the user logs in with valid username 'abc19072023@gmail.com' and password 'ecommerce123$'
@smoketest
Scenario: Applying Coupon
	When the user adds an item and applies the coupon code 'edgewords'
	Then the coupon applies 10% discount to the total plus shipping

@smoketest
Scenario: Completing Order
	When the user adds and item and checks out
	And the user completes the billing form
	Then the order number is generated and also visible in Orders Page