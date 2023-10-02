```markdown


This API serves as a platform for video-related tasks, including uploading, transcribing, and streaming.

## Live URL

The Live URL for all API endpoints is `http://fortunate3d-001-site1.atempurl.com/`.
##

## Endpoints

The API provides the following endpoints:

- `/startUpload`: Start a new video upload.
- `/UploadChunks`: Upload video chunks for an ongoing upload.
- `/UploadComplete`: Complete a video upload.
- `/StreamVideo/{uploadKey}`: Stream a video.
- `/DeleteVideo`: Delete a video.
- `/get-all`: Get a list of all uploaded videos.

For detailed documentation of each endpoint, please refer to the https://github.com/FortunateOmonuwa/HNGXStage5/blob/main/HNGxVideoStreaming/Documentation.md section below.

## Getting Started

To get started, follow these steps:

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/FortunateOmonuwa/HNGXStage5.git
   ```

2. Configure your environment variables, database, and storage settings as needed.

3. Build and run the application.

4. Access the API at the base URL mentioned above.

## API Documentation

For detailed documentation of the API endpoints, refer to the [API Documentation](API_DOCUMENTATION.md) file.

## Error Handling

If an error occurs during API requests, the API will return an error response with details in the `ErrorMessage` field. 

```
