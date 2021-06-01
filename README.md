# CreditCardRecruit.Api

## Assumptions
1. As the requirements are not clear enough, I assumed credit card information should be returned from get methods without any encryption.
2. CreditCardAttribute in CreditCardService isn't validating all the edge cases but I assumed CreditCardAttribute is enough to validate credit card number because of assignment completion time.
3. Encrypting credit card details into Base64 isn't safe but require more time to investiagte best encryptions methods.
4. Setting up temp storage for integration tests such as SQLLocalDb requires more time. 



## Recommendations
As we save credit card details, we need to spend more time to investigate non functional requirements, specially security. Such as where do we save credit card details, which encryption methods we should use to encript credit card details, user authentication and authorization for this api and legal requirements for encrypting and storing credit card details etc. 