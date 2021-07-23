import * as moment from 'moment';

export class CreateCidadeDto implements ICreateCidadeDto {
    id: string;
    nome: string | undefined;
    estadoId: string | undefined;
    lastLoginTime: moment.Moment | undefined;
    creationTime: moment.Moment;

    constructor(data?: ICreateCidadeDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
        else{
            this.id = "";
            this.nome = "";
            this.estadoId = "";
            this.creationTime = <any>undefined;
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.nome = data["nome"];
            this.estadoId = data["estadoId"];
            this.creationTime = data["creationTime"] ? moment(data["creationTime"].toString()) : <any>undefined;


        }
    }

    static fromJS(data: any): CreateCidadeDto {
        data = typeof data === 'object' ? data : {};
        let result = new CreateCidadeDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["nome"] = this.nome;
        data["estadoId"] = this.estadoId;
        data["creationTime"] = this.creationTime ? this.creationTime.toISOString() : <any>undefined;


        return data; 
    }

    clone(): CreateCidadeDto {
        const json = this.toJSON();
        let result = new CreateCidadeDto();
        result.init(json);
        return result;
    }

    Invlid(): boolean {
        let invalid = [];
        if (this.nome.length > 50)
            invalid.push(1);
        
        return invalid.length != 0;
    }
}

export interface ICreateCidadeDto {
    id: string;
    nome: string | undefined;
    estadoId: string | undefined;
    lastLoginTime: moment.Moment | undefined;
    creationTime: moment.Moment;
    
}