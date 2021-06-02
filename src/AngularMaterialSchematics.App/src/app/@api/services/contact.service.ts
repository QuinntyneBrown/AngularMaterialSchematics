import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Contact } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ContactService  {

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(): Observable<Contact[]> {
    return this._client.get<{ contacts: Contact[] }>(`${this._baseUrl}api/contact`)
      .pipe(
        map(x => x.contacts)
      );
  }

  public getById(options: { contactId: string }): Observable<Contact> {
    return this._client.get<{ contact: Contact }>(`${this._baseUrl}api/contact/${options.contactId}`)
      .pipe(
        map(x => x.contact)
      );
  }

  public remove(options: { contact: Contact }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/contact/${options.contact.contactId}`);
  }

  public create(options: { contact: Contact }): Observable<{ contact: Contact }> {
    return this._client.post<{ contact: Contact }>(`${this._baseUrl}api/contact`, { contact: options.contact });
  }

  public update(options: { contact: Contact }): Observable<{ contact: Contact }> {
    return this._client.put<{ contact: Contact }>(`${this._baseUrl}api/contact`, { contact: options.contact });
  }
}
