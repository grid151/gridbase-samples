# Place Order

## Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| orderDetails.ProductTypeDesc | Products Available to order | string |
| orderDetails.transactionTypeDesc | Transaction Type | string |
| Even Field Name TBD by SoftPro | Per SoftPro, they will add a Description field if 'Other' selected for Loan Type | string |
| parties.buyers.lastName | Buyers Last Name | string |
| parties.buyers.firstName | Buyers First Name | string |
| parties.lender.companyName | Lender Company Name | string |
| property.address.street | Property Address 1 | string |
| property.address.cityDesc | Property City Description | string |
| property.address.stateId | Property State | string |
| property.address.zip | Property Zip | string |

Required (Yes/No) Additional description if requirement is conditional.

Request body example

Response body example

# Update Order

## Required fields

== Updates will take the full order, anything left null should not replace an existing value.  (Will confirm with SoftPro) ==

| Field Name | Field Description | Data Type |
|---|---|---|
| orderDetails.ProductTypeDesc | Products Available to order | string |
| orderDetails.transactionTypeDesc | Transaction Type | string |
| Even Field Name TBD by SoftPro | Per SoftPro, they will add a Description field if 'Other' selected for Loan Type | string |
| parties.buyers.lastName | Buyers Last Name | string |
| parties.buyers.firstName | Buyers First Name | string |
| parties.lender.companyName | Lender Company Name | string |
| property.address.street | Property Address 1 | string |
| property.address.cityDesc | Property City Description | string |
| property.address.stateId | Property State | string |
| property.address.zip | Property Zip | string |



Request body example

Response body example

# Add Document

## Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| Test | This | Format |
| Test A | New | Line |
| Even | More | Testing |

Request body example

Response body example

# Add Note

## Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| Test | This | Format |
| Test A | New | Line |
| Even | More | Testing |

Request body example

Response body example

# Cancel Order

## Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| Test | This | Format |
| Test A | New | Line |
| Even | More | Testing |

Request body example

Response body example