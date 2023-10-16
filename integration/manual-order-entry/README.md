# GridBase Manual Order Entry

This README file describes several API endpoints for using Manual Order Entry, an order management feature that allows lenders to place orders in GridBase without a destination integration. This file provides detailed information on the required fields for each endpoint.


## Table of Contents

- [Stage Order](#stage-order)
- [Update Order](#update-order)
- [Place Order](#place-order)
- [Add Document](#add-document)
- [Add Note](#add-note)
- [Send Invitation](#send-invitation)
- [Resend Invitation](#resend-invitation)


## Stage Order
To stage an order, submit an HTTP POST request to /v1/orders/stage using the example request.

### Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| property.address.street | Property Address | string |
| property.address.cityDesc | Property City | string |
| property.address.stateId | Property State | string |
| property.address.zip | Property Zip | string |

### Request body example

Here is a an [example request body](sample/order.json)


## Update Order
 Once staged, you may optionally update the order object by submitting an HTTP PUT requests to /v1/orders/update.
### Required fields


| Field Name | Field Description | Data Type |
|---|---|---|
| property.address.street | Property Address | string |
| property.address.cityDesc | Property City | string |
| property.address.stateId | Property State | string |
| property.address.zip | Property Zip | string |


Here is a an [example request body](sample/order.json)


## Place Order
 Once staged, you can place the order by submitting an HTTP PUT requests to /v1/orders/place/{orderId}.


## Add Document
New documents can be attached to a placed order by submitting an HTTP POST request to /v1/documents/create/{orderId}.
### Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| fileName | Name of file without extension | string |
| documentBody | Document as a Base64 string | string |
| extension | extenstion of the uploaded file txt, pdf, etc | string |

Here is a an [example document upload request body](sample/document.json)


## Add Note
New notes can be added to a placed order by submitting an HTTP PUT request to /v1/notes/add/{orderId}.
### Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| noteSubject | Note Subject | string |
| noteBody | Note Body | string |

### Request body example

```json
{
  "noteSubject": "<string>",
  "noteBody": "<string>"
}
```


### Send Invitation

Order invitations can be sent to individuals outside the organization.  An email will be sent to the provided address, granting access to view the order, add notes, and add documents.  Invitations can be sent by submitting an HTTP POST request to `/v1/core/invitation/send`.
### Required fields

| Field Name | Field Description | Data Type |
|---|---|---|
| orderId | Order Id | string |
| email | Email Address | string |
| firstName | First Name | string |
| lastName | Last Name | string |

```json
{
    "OrderId": "<string>",
    "Email": "<string>",
    "FirstName": "<string>",
    "LastName": "<string>",
}
```


### Resend Invitation

Invitations can be resent by submitting an HTTP POST request to `/v1/core/invitation/resend` with a request body like:
```json
{
    "InvitationId": "<string>"
}
```
