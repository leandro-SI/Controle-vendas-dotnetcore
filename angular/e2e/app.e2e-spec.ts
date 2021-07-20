import { ControleVendasTemplatePage } from './app.po';

describe('ControleVendas App', function() {
  let page: ControleVendasTemplatePage;

  beforeEach(() => {
    page = new ControleVendasTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
