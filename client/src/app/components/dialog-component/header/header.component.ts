import { Component, ViewChild, ElementRef } from '@angular/core';
import { saxCloseCircleBold, saxCameraBold } from '@ng-icons/iconsax/bold';

import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { MatMenuModule } from '@angular/material/menu';

@Component({
  selector: 'dialog-header',
  standalone: true,
  imports: [NgIconComponent, MatMenuModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
  viewProviders: provideIcons({
    saxCloseCircleBold,
    saxCameraBold,
  }),
})
export class HeaderComponent {
  @ViewChild('fileInput')
  set fileInput(val: ElementRef) {
    if (val) {
      console.log(val);
    }
  }

  file: File | null = null;

  onChangeFileInput(): void {
    const files: { [key: string]: File } = this.fileInput.nativeElement.files;
    this.file = files[0];
  }
}
