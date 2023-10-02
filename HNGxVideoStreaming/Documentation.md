# Video Upload API Documentation

## Base URL

The base URL for all API endpoints is `http://fortunate3d-001-site1.atempurl.com/`.

This documentation provides an overview of the Video Upload API endpoints and their functionality.

## Endpoints

## 1. Upload Video Chunks

- **URL**: `/UploadChunks`
- **Method**: POST
- **Description**: Upload video chunks for an ongoing upload operation.
- **Parameters**:
  - `uploadKey` (string): The unique key for the upload context.
- **Request Body**: Binary video chunk data.
- **Response**: Information about the upload operation.
- **Example Request**:

POST /VideoUpload/UploadChunks?uploadKey=your_upload_key_here

- **Example Response**:

```json
{
  "message": "Video chunk uploaded successfully.",
  "uploadStatus": "In progress"
}
```

## 2. URL: /UploadComplete

Method: POST

**Description: Complete a video upload, merge chunks, and extract audio.**

**Parameters:**

- uploadKey (string): The unique key for the upload context.

- Response:
  videoUrl (string): The URL to access the uploaded video.

- transcribe (array): An array of transcribed data.

### Example Request:

```
POST /VideoUpload/UploadComplete?uploadKey=your_upload_key_here
```

### Example Response:

```
{
  "videoUrl": "https://your-video-url.com",
  "transcribe": ["Transcription text 1", "Transcription text 2"]
}

```

## 3. Stream Video

- **URL: /StreamVideo/{uploadKey}**

- **Method: GET**
  **Description: Stream a video by providing the upload key.**

- **Parameters:**

- uploadKey (string): The unique key for the upload context.

- Response: Video stream.

### Example Request:

```
GET /VideoUpload/StreamVideo/your_upload_key_here

```

## 4. Delete Video

- **URL: /DeleteVideo**

- **Method: DELETE**
**Description: Delete a video and associated data.**

- **Parameters:**

- uploadKey (string): The unique key for the upload context.
- Response: Information about the deletion operation.


### Example Request:

```
DELETE /VideoUpload/DeleteVideo?uploadKey=your_upload_key_here

```
