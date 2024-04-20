export interface BranchNames {
  data: {
    stream: {
      name: string;
      branches: {
        cursor: string;
        totalCount: number;
        items: {
          name: string;
        }[];
      };
    };
  };
}