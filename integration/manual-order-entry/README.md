# GridBase Manual Order Entry

This README file describes several API endpoints for using Manual Order Entry, an order management feature that allows lenders to place orders in GridBase without a destination integration. This file provides detailed information on the required fields for each endpoint.


## Table of Contents

- [Stage Order](#stage-order)
- [Update Order](#update-order)
- [Place Order](#place-order)
- [Add Note](#add-note)
- [Add Document](#add-document)
- [Send Invitation](#send-invitation)
- [Resend Invitation](#resend-invitation)
- [Edit Invitation](#edit-invitation)
- [Disable Invitation](#disable-invitation)
- [Order Update Notifications](#order-update-notifications)


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

Here is a [sample request body](sample/order.json)


## Update Order
Once staged, you may optionally update the order object by submitting an HTTP PUT requests to /v1/orders/update.

### Required fields
| Field Name | Field Description | Data Type |
|---|---|---|
| property.address.street | Property Address | string |
| property.address.cityDesc | Property City | string |
| property.address.stateId | Property State | string |
| property.address.zip | Property Zip | string |


Here is a [sample request body](sample/order.json)


## Place Order
Once staged, you can place the order by submitting an HTTP PUT requests to /v1/orders/place/{orderId}.


## Add Note
New notes can be added to a placed order by submitting an HTTP PUT request to /v1/notes/add/{orderId}.

### Required fields
| Field Name | Field Description | Data Type |
|---|---|---|
| noteSubject | Note Subject | string |
| noteBody | Note Body | string |

Here is a [sample note request body](sample/note.json)


## Add Document
New documents can be attached to a placed order by submitting an HTTP POST request to /v1/documents/create/{orderId}.

### Required fields
| Field Name | Field Description | Data Type |
|---|---|---|
| fileName | Name of file without extension | string |
| documentBody | Document as a Base64 string | string |
| extension | extenstion of the uploaded file txt, pdf, etc | string |

Here is a [sample document upload request body](sample/document.json)


## Send Invitation
Order invitations can be sent to individuals outside the organization.  An email will be sent to the provided address, granting access to view the order, add notes, and add documents.  Invitations can be sent by submitting an HTTP POST request to `/v1/core/invitation/send`.

### Required fields
| Field Name | Field Description | Data Type |
|---|---|---|
| orderId | Order Id | string |
| email | Email Address | string |
| firstName | First Name | string |
| lastName | Last Name | string |

Here is a [sample invitation request body](sample/note.json)


## Resend Invitation
Invitations can be resent by submitting an HTTP POST request to `/v1/core/invitation/resend` with a request body like:

```json
{
    "invitationId": "<string>"
}
```


## Edit Invitation
Invitations names can be updated by submitting an HTTP PATCH request to `/v1/core/invitation/update` with a request body like:

```json
{
    "id": "4ab---------------21d",
    "firstName": "John",
    "lastName": "Doe"
}
```


## Disable Invitation
Order invitations can be enabled or disabled by submitting an HTTP PATCH request to `/v1/core/invitation/update` with a request body like:

```json
{
    "id": "4ab---------------21d",
    "flag": "Enabled",
    "flagValue": true
}
```


## Order Update Notifications
Invitees may receive order update email notifications when notes or documents are added to the order by a member of the creating organzation.  This flag can
be toggled by submitting an HTTP PATCH request to `/v1/core/invitation/update` with a request body like:

```json
{
    "id": "4ab-------------21d",
    "flag": "EmailUpdates",
    "flagValue": true
}
```
