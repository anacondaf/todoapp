import { Component } from '@angular/core';

import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';

import { HeaderComponent } from './header/header.component';

// import { saxCloseCircleBold } from '@ng-icons/iconsax/bold';
import { ionClose } from '@ng-icons/ionicons';

@Component({
  selector: 'app-dialog-component',
  standalone: true,
  imports: [NgIconComponent, MatDialogModule, MatButtonModule, HeaderComponent],
  templateUrl: './dialog.component.html',
  styleUrl: './dialog-content.style.scss',
  viewProviders: provideIcons({
    ionClose,
  }),
})
export class DialogComponent {}
