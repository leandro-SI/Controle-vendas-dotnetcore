import { Component, Injector, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CidadeDto } from '@shared/models/cidade/cidadeDto';
import { CidadeDtoPagedResultDto } from '@shared/models/cidade/cidadeDtoPagedResultDto';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { CidadeServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/internal/operators/finalize';

class PagedCidadeRequestDto extends PagedRequestDto {
  keyword: string;
  status: number | undefined;
}

@Component({
  selector: 'app-cidade',
  templateUrl: './cidade.component.html',
  styleUrls: ['./cidade.component.css'],
  animations: [appModuleAnimation()]
})
export class CidadeComponent extends PagedListingComponentBase<CidadeDto> {  
  advancedFiltersVisible: boolean = false;
  keyword: string = '';
  status: number | undefined;
  cidades: CidadeDto[] = [];

  constructor(injector: Injector, private _router: Router, private cidadeService: CidadeServiceProxy) {
    super(injector);
  }

  clearFilters(): void {
    this.keyword = '';
    this.status = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedCidadeRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.status = this.status;
    this.cidadeService
      .getAll(request.keyword, request.status, request.skipCount, request.maxResultCount )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: CidadeDtoPagedResultDto) => {
        this.cidades = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(cidade: CidadeDto): void {

  }

  public novo(){
    this._router.navigate(['/app/cidade/novo/']);
  }

  public detalhe(id:any){
  }

  public editar(id:any){
  }

  public voltar(){
    this._router.navigate(['/app/cidades/']);
  }
}