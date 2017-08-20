import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Organization } from '../models/organization';

@Injectable()
export class OrganizationService {

  private headers = new Headers({'Content-Type': 'application/json'});
  private organizationsUrl = 'http://localhost:7624/api/organizations';

  constructor(private http: Http) { }

  // Get a single organization
  getOrganization(code: string): Promise<Organization> {
    const url = `${this.organizationsUrl}/${code}`;
    return this.http.get(url)
      .toPromise()
      .then(response => response.json().data as Organization)
      .catch(this.handleError);
  }

  // Get all organizations
  getOrganizations(): Promise<Organization[]> {
    console.log(this.organizationsUrl);
    return this.http.get(this.organizationsUrl)
      .toPromise()
      .then(response => response.json() as Organization)
      .catch(this.handleError);
  }

  // Delete an organization
  delete(code: string): Promise<void> {
    const url = `${this.organizationsUrl}/${code}`;
    return this.http.delete(url, {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }

  // Create an organization
  create(organization: Organization): Promise<Organization> {
    return this.http
    .post(this.organizationsUrl, JSON.stringify(organization), {headers: this.headers})
    .toPromise()
    .then(res => res.json().data as Organization)
    .catch(this.handleError);    
  }

  // Update an organization
  update(organization: Organization): Promise<Organization> {
    const url = `${this.organizationsUrl}/${organization.code}`;
    return this.http
      .put(url, JSON.stringify(organization), {headers: this.headers})
      .toPromise()
      .then(() => organization)
      .catch(this.handleError);
  }

  // Handle error 
  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }

}
