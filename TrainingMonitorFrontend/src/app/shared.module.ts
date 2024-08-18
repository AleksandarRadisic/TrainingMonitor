import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompareDirective } from './directives/compare.directive';

@NgModule({
  declarations: [CompareDirective],
  imports: [CommonModule],
  exports: [CompareDirective]
})
export class SharedModule { }