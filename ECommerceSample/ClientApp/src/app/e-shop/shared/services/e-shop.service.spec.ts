import { TestBed } from "@angular/core/testing";

import { EShopService } from "./e-shop.service";

describe("EShopService", () => {
  let service: EShopService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EShopService);
  });

  it("should be created", () => {
    expect(service).toBeTruthy();
  });
});
