# contact-tracing-api
Contact tracing API provides endpoints for a mobile app to report the case and enforce risk notification


docker build -t contact-tracing-api  .
docker run -d -p 8000:8080 contact-tracing-api