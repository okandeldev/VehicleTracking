FROM node:18-alpine AS build
WORKDIR /app

RUN npm install -g @angular/cli

COPY ./package.json .
RUN npm install
COPY . .
RUN npm run build-docker

FROM nginx as runtime
COPY --from=build /app/dist/vehicle-tracking-ui /usr/share/nginx/html

# Start NgInx service
# ENTRYPOINT ["./usr/share/nginx/html/start.sh", "$CONFIGURATION"]
