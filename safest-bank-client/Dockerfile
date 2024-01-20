FROM node:20.11-alpine AS build
WORKDIR /app
COPY . .
RUN npm ci 
RUN npm run build

FROM nginx:1.23.3-alpine AS production
COPY --from=build /app/build /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
CMD ["nginx", "-g", "daemon off;"]