import { PruebaApiSpaTemplatePage } from './app.po';

describe('PruebaApiSpa App', function() {
  let page: PruebaApiSpaTemplatePage;

  beforeEach(() => {
    page = new PruebaApiSpaTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
