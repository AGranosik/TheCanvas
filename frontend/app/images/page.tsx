"use client";

import {
  ReactCompareSlider,
  ReactCompareSliderImage,
} from "react-compare-slider";

export default function Home() {
  const state = {
    now: "/Copenhagen-UTCI-now.jpg",
    later: "/Copenhagen-UTCI-2050.jpg",
  };

  return (
    <div className="grid h-screen w-full pl-[53px]">
      <ReactCompareSlider
        itemOne={<ReactCompareSliderImage src={state.now} alt="Image one" />}
        itemTwo={<ReactCompareSliderImage src={state.later} alt="Image two" />}
      />
    </div>
  );
}
