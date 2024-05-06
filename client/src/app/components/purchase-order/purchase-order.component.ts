import { Component } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { saxHome2Outline, saxDirectOutline } from '@ng-icons/iconsax/outline';
import { saxAddBold } from '@ng-icons/iconsax/bold';

import { UserBoxComponent } from '../header/user/user.component';
import { DialogContentExampleDialog } from '../dialog-component/dialog-content/dialog-content.component';

import { PurchaseTableComponent } from './table/table.component';

@Component({
  selector: 'app-content-fill',
  standalone: true,
  imports: [
    NgIconComponent,
    UserBoxComponent,
    MatDialogModule,
    PurchaseTableComponent,
  ],
  templateUrl: './purchase-order.component.html',
  styleUrl: './purchase-order.component.css',
  viewProviders: [
    provideIcons({ saxHome2Outline, saxDirectOutline, saxAddBold }),
  ],
})
export class ContentFillComponent {
  constructor(public dialog: MatDialog) {}

  openDialog() {
    const dialogRef = this.dialog.open(DialogContentExampleDialog);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
