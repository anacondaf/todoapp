import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { saxHome2Outline, saxDirectOutline } from '@ng-icons/iconsax/outline';
import { saxAddBold } from '@ng-icons/iconsax/bold';

import { UserBoxComponent } from '../header/user/user.component';
import { DialogComponent } from '../dialog-component/dialog.component';

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
  styleUrl: './purchase-order.component.scss',
  viewProviders: [
    provideIcons({ saxHome2Outline, saxDirectOutline, saxAddBold }),
  ],
})
export class ContentFillComponent implements OnInit {
  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {
    console.log(this.dialog);
  }

  openDialog() {
    const dialogRef = this.dialog.open(DialogComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
