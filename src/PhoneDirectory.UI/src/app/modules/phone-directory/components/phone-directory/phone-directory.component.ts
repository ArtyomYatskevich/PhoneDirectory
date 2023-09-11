import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { Phone } from '../../models/phone.model';
import { PhoneDirectoryService } from '../../services/phone-directory.service';
import { AddEditPhoneComponent } from '../add-edit-phone/add-edit-phone.component';
import { ConfirmationDialogModel } from '@shared/models/confirmation-dialog.model';
import { ConfirmationDialogComponent } from '@shared/components/confirmation-dialog/confirmation-dialog.component';

@Component({
    selector: 'app-phone-directory',
    templateUrl: './phone-directory.component.html',
    styleUrls: ['./phone-directory.component.scss']
})
export class PhoneDirectoryComponent {
    phones: Phone[] = [];

    constructor(
        private phoneDirectoryService: PhoneDirectoryService,
        public dialog: MatDialog
    ) {}
  
    ngOnInit() {
        this.phoneDirectoryService.getAll()
        .subscribe(data => {
            this.phones = data;
        });
    }
  
    add(): void {
        const dialogRef = this.dialog.open(AddEditPhoneComponent, { data: null });

        dialogRef.afterClosed().subscribe(result => {
            if (!!result.id) {
                this.phones.push(result);
            }
        });
    }

    update(phone: Phone): void {
        const dialogRef = this.dialog.open(AddEditPhoneComponent, { data: phone });

        dialogRef.afterClosed().subscribe(result => {
            const index = this.phones.findIndex(x => x.id === result.id);
            this.phones[index] = result;
        });
    }
  
    remove(phone: Phone): void {
        const data: ConfirmationDialogModel = {
            title: 'Confirm delete',
            message: `Are you sure you want to delete '${phone.number}'`
        }

        const dialogRef = this.dialog.open(ConfirmationDialogComponent, { data: data });
        dialogRef.afterClosed().subscribe(result => {
            if (!result) {
                return;
            }

            this.phoneDirectoryService.deletePhone(phone.id).subscribe(_ => {
                this.phones = this.phones.filter(x => x.id !== phone.id);
            });
        });
    }
}
