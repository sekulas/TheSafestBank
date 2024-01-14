FROM node:20.11.0 AS build

WORKDIR /app
COPY . .

RUN npm install

CMD ["npm", "start"]