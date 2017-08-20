import { Organization } from './../models/organization';
import { OrganizationService } from './../services/organization.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.scss']
})
export class EntryComponent implements OnInit {

  organizations: Organization[];
  
  constructor(private organizationService: OrganizationService) { }

  ngOnInit() {
    this.getOrganizations();
  }

  getOrganizations(): void {
    this.organizationService 
      .getOrganizations()
      .then(organizations => this.organizations = organizations);
  }

}
