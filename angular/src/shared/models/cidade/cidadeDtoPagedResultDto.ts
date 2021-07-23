import { CidadeDto } from './cidadeDto';

export class CidadeDtoPagedResultDto implements ICidadeDtoPagedResultDto {
    totalCount: number;
    items: CidadeDto[] | undefined;

    constructor(data?: ICidadeDtoPagedResultDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.totalCount = data["totalCount"];
            if (Array.isArray(data["items"])) {
                this.items = [] as any;
                for (let item of data["items"])
                    this.items.push(CidadeDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): CidadeDtoPagedResultDto {
        data = typeof data === 'object' ? data : {};
        let result = new CidadeDtoPagedResultDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["totalCount"] = this.totalCount;
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        return data; 
    }

    clone(): CidadeDtoPagedResultDto {
        const json = this.toJSON();
        let result = new CidadeDtoPagedResultDto();
        result.init(json);
        return result;
    }
}

export interface ICidadeDtoPagedResultDto {
    totalCount: number;
    items: CidadeDto[] | undefined;
}