import { Directive, Input } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl, ValidationErrors } from '@angular/forms';

@Directive({
  selector: '[compare]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: CompareDirective,
    multi: true
  }]
})
export class CompareDirective implements Validator {
  @Input('compare') compareTo: string = '';

  validate(control: AbstractControl): ValidationErrors | null {
    if (this.compareTo !== control.value) {
      return { 'compare': true };
    }
    return null;
  }
}