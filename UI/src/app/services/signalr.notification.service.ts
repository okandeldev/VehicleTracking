import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import {} from '@angular/core';
import { NotificationDTO } from '../dtos/notification.dto';
import { environment } from '../../environments/environment';
@Injectable({
  providedIn: 'root',
})
export class SignalrNotificationService {
  public notifications: NotificationDTO[] = [];
  constructor() {}
  private hubConnection: signalR.HubConnection;
  public startConnection = async () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.services.socketEndpoints.notifications, {})
      .withAutomaticReconnect()
      .configureLogging(signalR.LogLevel.Debug)
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch((err) => console.log('Error while starting connection: ' + err));

    this.hubConnection.onclose((error) => {
      this.hubConnection
        .start()
        .then(() => console.log('Connection re-started'))
        .catch((err) =>
          console.log('Error while re-starting connection: ' + err)
        );
    });
  };
  public addTransferNotificationsDataListener = (callback: any) => {
    this.hubConnection.on('vehiclePingNotificationData', (data: any) => {
      this.handle(data);
      callback(data);
    });
  };

  public handle = (data: any) => {
    console.log('vehiclePingNotificationData', data, typeof data);
  };
}
