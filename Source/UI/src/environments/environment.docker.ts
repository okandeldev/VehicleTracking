export const environment = {
  production: true,
  baseUrl: 'http://localhost:8003/api',
  services: {
    socketEndpoints: {
      notifications: 'http://localhost:8000/notifications',
    },
  },
  VehicleIsDisconnectedMins: 1,
};
