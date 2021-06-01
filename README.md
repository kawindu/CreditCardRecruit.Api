# CreditCardRecruit.Api

## Assumptions
1. As the requirements are not clear enough, I assumed credit card information should be return without any encryption.
2. CreditCardAttribute in CreditCardService isn't validating all the edge cases but I assumed it is enough because of assignment completion time.
3. Encrypting credit card details into Base64 is safe but require more time to investiagte best encryptions methods.



## Recommendations
As we save credit card details, we need to spend more time to investigate non functional requirements, specially security. 
Such as where do we save credit card details, which encryptions methods we should use to encript credit card details, who have access to the api etc. 