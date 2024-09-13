
Key Features:
Support for uploading files in CSV and XML formats
Automatic validation and parsing of uploaded files
Ability to query transactions by currency, date range, and status
Unified transaction status mapping for CSV and XML files
Robust error handling and logging mechanism


Assumptions:
The average file size uploaded will be around 500 KB.
The system will be deployed on a Windows Server 2019 environment with .NET 6.0 installed.
The system will be used primarily for uploading transactions.


Known Issues:
The system does not currently support uploading files larger than 1 MB.
The system does not have a built-in mechanism for handling duplicate transactions.
The system does not support querying transactions by other criteria beyond currency, date range, and status.
